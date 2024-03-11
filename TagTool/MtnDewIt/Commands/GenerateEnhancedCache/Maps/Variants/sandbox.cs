using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @sandbox : MapVariantFile
    {
        public @sandbox(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\sandbox\sandbox");
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
                    MapId = 730,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandkasten",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                            Name = $@"沙箱",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Sandbox",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"This endless wasteland still holds many secrets. Some of them are held more deeply than others. 4-12 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"砂の下には地下エリアが隠されている広大な荒地|n(4-12 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Dieses endlose Ödland birgt noch viele Geheimnisse, von denen einige besser verborgen sind als andere. 4-12 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"L'infini de ces terres désolées renferme encore de nombreux secrets. Certains sont mieux cachés que d'autres. 4-12 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Este yermo interminable aún alberga muchos secretos, algunos más profundos que otros. Jugadores: 4-12.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Este yermo interminable aún alberga muchos secretos, algunos más profundos que otros. Jugadores: 4-12.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Queste sconfinate terre devastate racchiudono ancora molti segreti. Alcuni nascosti più in profondità di altri. 4-12 gioc.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"이 끝없는 불모지는 여전히 많은 비밀을 가지고 있습니다. 4-12인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"這片無盡的荒地仍然有許多秘密，一個比一個神秘。4-12 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Este deserto interminável ainda abriga muitos segredos. Alguns deles são mais bem guardados que os outros. 4-12 jog.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_sandbox",
                    MapName = $@"sandbox",
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
                            Name = $@"Sandbox",
                            Description = $@"This endless wasteland still holds many secrets. Some of them are held more deeply than others. 4-12 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 730,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 730,
                        WorldBounds = new RealRectangle3d(-264.412f, 258.6315f, -292.0574f, 230.9861f, -70.12542f, 167.9115f),
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
                                QuotaIndex = 0,
                                Position = new RealPoint3d(-11.67775f, 12.12028f, -22.54902f),
                                Forward = new RealVector3d(-0.03997945f, -0.9842145f, -0.1724049f),
                                Up = new RealVector3d(0.1156416f, -0.175941f, 0.9775847f),
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
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                QuotaIndex = 0,
                                Position = new RealPoint3d(8.870285f, -31.00875f, -22.71568f),
                                Forward = new RealVector3d(7.54979E-08f, 0.9999403f, -0.01092127f),
                                Up = new RealVector3d(1.363922E-06f, 0.01092127f, 0.9999403f),
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
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                QuotaIndex = 114,
                                Position = new RealPoint3d(-119.7454f, -12.79028f, 41.14079f),
                                Forward = new RealVector3d(0.9999821f, 0.005978493f, 0f),
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
                                QuotaIndex = 114,
                                Position = new RealPoint3d(-59.8416f, 90.89574f, 41.14079f),
                                Forward = new RealVector3d(0.5695829f, -0.8219339f, 0f),
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
                                QuotaIndex = 114,
                                Position = new RealPoint3d(59.84029f, 90.85736f, 41.14079f),
                                Forward = new RealVector3d(-0.5679013f, -0.8230967f, 0f),
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
                                QuotaIndex = 114,
                                Position = new RealPoint3d(119.6715f, -12.78036f, 41.14079f),
                                Forward = new RealVector3d(-0.9999602f, 0.008923563f, 0f),
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
                                QuotaIndex = 114,
                                Position = new RealPoint3d(59.8475f, -116.4597f, 41.14079f),
                                Forward = new RealVector3d(-0.5088074f, 0.8608804f, 0f),
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
                                QuotaIndex = 114,
                                Position = new RealPoint3d(-59.90669f, -116.4587f, 41.14079f),
                                Forward = new RealVector3d(0.5819467f, 0.8132269f, 0f),
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
                                Position = new RealPoint3d(4.81907f, 6.95811f, -22.74346f),
                                Forward = new RealVector3d(0.9889918f, 0.007345794f, 0.1477883f),
                                Up = new RealVector3d(-0.1477723f, -0.00267942f, 0.9890178f),
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
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                Position = new RealPoint3d(-8.335705f, -25.91191f, -22.74355f),
                                Forward = new RealVector3d(-0.988719f, 0.003160679f, 0.1497488f),
                                Up = new RealVector3d(0.1497364f, -0.003870651f, 0.9887183f),
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
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                Position = new RealPoint3d(6.543671f, 12.87308f, -22.73665f),
                                Forward = new RealVector3d(0.9995677f, 1.247495E-07f, -0.02939892f),
                                Up = new RealVector3d(0.02939892f, -2.189193E-06f, 0.9995677f),
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
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                Position = new RealPoint3d(-7.745644f, 12.9265f, -22.73829f),
                                Forward = new RealVector3d(-0.9995981f, -8.750404E-05f, -0.02834844f),
                                Up = new RealVector3d(-0.02834858f, 0.00265981f, 0.9995946f),
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
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                Position = new RealPoint3d(4.200432f, -31.9366f, -22.7369f),
                                Forward = new RealVector3d(0.9995544f, 5.910672E-08f, -0.02984944f),
                                Up = new RealVector3d(0.02984944f, -5.494203E-07f, 0.9995544f),
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
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                Position = new RealPoint3d(-9.543308f, -31.94867f, -22.73688f),
                                Forward = new RealVector3d(-0.9995545f, -2.846829E-07f, -0.02984793f),
                                Up = new RealVector3d(-0.02984793f, 4.476946E-06f, 0.9995545f),
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
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
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
                                QuotaIndex = 7,
                                Position = new RealPoint3d(1.329562f, 4.749468f, -20.89905f),
                                Forward = new RealVector3d(-0.1255738f, -0.9920641f, -0.006333938f),
                                Up = new RealVector3d(0.9920796f, -0.1255511f, -0.003868815f),
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
                                QuotaIndex = 20,
                                Position = new RealPoint3d(-3.612616f, 4.937491f, -20.90422f),
                                Forward = new RealVector3d(0.1076232f, -0.9941587f, 0.008106291f),
                                Up = new RealVector3d(-0.9935939f, -0.1072722f, 0.03555135f),
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
                                QuotaIndex = 7,
                                Position = new RealPoint3d(-5.761156f, -24.10992f, -20.89875f),
                                Forward = new RealVector3d(-0.1060614f, -0.9943144f, -0.009486765f),
                                Up = new RealVector3d(0.9943237f, -0.1061338f, 0.007480302f),
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
                                QuotaIndex = 20,
                                Position = new RealPoint3d(0.2945929f, -23.64155f, -20.90483f),
                                Forward = new RealVector3d(0.1000787f, -0.9949786f, 0.001375496f),
                                Up = new RealVector3d(-0.9943885f, -0.09997148f, 0.03460028f),
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
                                QuotaIndex = 15,
                                Position = new RealPoint3d(-12.32095f, -19.59817f, -22.65336f),
                                Forward = new RealVector3d(0.8668434f, 0.4984322f, -0.01215935f),
                                Up = new RealVector3d(-0.497971f, 0.8667317f, 0.02830312f),
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
                                    SpawnTime = 60,
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
                                QuotaIndex = 15,
                                Position = new RealPoint3d(9.041218f, 0.9719618f, -22.60936f),
                                Forward = new RealVector3d(0.8452885f, 0.5339482f, -0.01966499f),
                                Up = new RealVector3d(-0.533576f, 0.8454838f, 0.02130392f),
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
                                    SpawnTime = 60,
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
                                Position = new RealPoint3d(-2.603702f, -23.75035f, -22.64018f),
                                Forward = new RealVector3d(0.001170781f, 0.4622174f, 0.8867658f),
                                Up = new RealVector3d(-0.02995645f, 0.8863847f, -0.4619792f),
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
                                QuotaIndex = 14,
                                Position = new RealPoint3d(-0.6961025f, 4.503139f, -22.56768f),
                                Forward = new RealVector3d(0.05733576f, -0.6296964f, -0.7747226f),
                                Up = new RealVector3d(0.01558558f, -0.77534f, 0.6313516f),
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
                                QuotaIndex = 18,
                                Position = new RealPoint3d(-6.776519f, -8.070167f, -22.67829f),
                                Forward = new RealVector3d(0.9979563f, -0.06283872f, 0.01159638f),
                                Up = new RealVector3d(0.06278759f, 0.9980157f, 0.004721306f),
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
                                QuotaIndex = 18,
                                Position = new RealPoint3d(2.589041f, -11.04122f, -22.66941f),
                                Forward = new RealVector3d(0.9986543f, -0.05184532f, -0.001295101f),
                                Up = new RealVector3d(0.05184308f, 0.9986538f, -0.001700181f),
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
                                QuotaIndex = 7,
                                Position = new RealPoint3d(7.260563f, -22.18537f, -22.59017f),
                                Forward = new RealVector3d(0.5562166f, 0.03290982f, 0.8303855f),
                                Up = new RealVector3d(0.01950469f, -0.9994572f, 0.02654565f),
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
                                QuotaIndex = 7,
                                Position = new RealPoint3d(-9.819603f, 4.9446f, -22.58522f),
                                Forward = new RealVector3d(-0.5684119f, -0.3244729f, 0.7560591f),
                                Up = new RealVector3d(0.5337228f, -0.844773f, 0.03871186f),
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
                                QuotaIndex = 13,
                                Position = new RealPoint3d(-7.960904f, -15.56912f, -22.1614f),
                                Forward = new RealVector3d(0.9999982f, -0.001907639f, -4.139009E-05f),
                                Up = new RealVector3d(0.001907649f, 0.9999982f, 0.0002336061f),
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
                                QuotaIndex = 13,
                                Position = new RealPoint3d(6.016262f, -5.518922f, -22.17638f),
                                Forward = new RealVector3d(0.9996665f, 0.02580971f, -0.0008777833f),
                                Up = new RealVector3d(0.02581261f, -0.9996608f, 0.00347112f),
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
                                QuotaIndex = 7,
                                Position = new RealPoint3d(-12.47356f, -23.86899f, -22.58829f),
                                Forward = new RealVector3d(-0.5744529f, -0.03522525f, 0.8177794f),
                                Up = new RealVector3d(0.02677742f, 0.9977301f, 0.06178642f),
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
                                QuotaIndex = 7,
                                Position = new RealPoint3d(9.332055f, 5.084516f, -22.57556f),
                                Forward = new RealVector3d(0.5312284f, -0.0008055391f, 0.8472283f),
                                Up = new RealVector3d(-0.8471993f, -0.008831002f, 0.5312018f),
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
                                QuotaIndex = 115,
                                Position = new RealPoint3d(6.410174f, -118.1021f, -15.00817f),
                                Forward = new RealVector3d(0.00716416f, -0.859221f, 0.5115543f),
                                Up = new RealVector3d(-0.1188201f, 0.5072117f, 0.8535912f),
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
                                QuotaIndex = 32,
                                Position = new RealPoint3d(-1.88827f, -9.519506f, -22.8322f),
                                Forward = new RealVector3d(0.9992917f, 0.000427171f, 0.03762858f),
                                Up = new RealVector3d(-0.0376293f, 0.02086139f, 0.999074f),
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
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-8.271789f, -3.535188f, -21.6677f),
                                Forward = new RealVector3d(1f, 1.59723E-11f, -2.850659E-06f),
                                Up = new RealVector3d(2.850659E-06f, 2.909761E-06f, 1f),
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
                                QuotaIndex = 26,
                                Position = new RealPoint3d(4.138029f, -15.26724f, -21.6619f),
                                Forward = new RealVector3d(1f, -3.165103E-13f, -1.868346E-05f),
                                Up = new RealVector3d(1.868346E-05f, -2.457752E-09f, 1f),
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
                                QuotaIndex = 30,
                                Position = new RealPoint3d(-0.6894337f, 7.954589f, -20.76662f),
                                Forward = new RealVector3d(0.9997804f, -0.002542411f, -0.02080074f),
                                Up = new RealVector3d(0.02087531f, 0.03405636f, 0.9992019f),
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
                                QuotaIndex = 30,
                                Position = new RealPoint3d(-2.689466f, -26.42256f, -20.74306f),
                                Forward = new RealVector3d(0.9987116f, -0.002534214f, -0.05068239f),
                                Up = new RealVector3d(0.05073921f, 0.03387406f, 0.9981373f),
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
                                QuotaIndex = 24,
                                Position = new RealPoint3d(8.633992f, -3.618131f, -22.71906f),
                                Forward = new RealVector3d(0.2259504f, -0.1989606f, -0.9536042f),
                                Up = new RealVector3d(0.5817081f, -0.7576624f, 0.2959112f),
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
                                Position = new RealPoint3d(7.544423f, 10.08694f, -22.71059f),
                                Forward = new RealVector3d(0.03292104f, -9.493897E-08f, -0.999458f),
                                Up = new RealVector3d(0.999458f, -2.218994E-07f, 0.03292104f),
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
                                Position = new RealPoint3d(-11.01221f, -29.07018f, -22.69929f),
                                Forward = new RealVector3d(-0.01516045f, -0.02958973f, -0.9994471f),
                                Up = new RealVector3d(-0.2701142f, -0.9622766f, 0.03258657f),
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
                                Position = new RealPoint3d(-11.45451f, -29.37599f, -22.6993f),
                                Forward = new RealVector3d(-0.06161517f, -0.1201843f, -0.9908377f),
                                Up = new RealVector3d(-0.266254f, -0.9547711f, 0.1323665f),
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
                                Position = new RealPoint3d(-11.71204f, -14.22698f, -22.71577f),
                                Forward = new RealVector3d(-0.1731276f, 0.05004951f, -0.9836269f),
                                Up = new RealVector3d(-0.8793428f, 0.441967f, 0.177261f),
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
                                Position = new RealPoint3d(-11.40816f, -13.95502f, -22.71596f),
                                Forward = new RealVector3d(-0.07172844f, 0.0205618f, -0.9972123f),
                                Up = new RealVector3d(-0.8921515f, 0.4457394f, 0.07336235f),
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
                                Position = new RealPoint3d(7.762138f, 10.51044f, -22.71111f),
                                Forward = new RealVector3d(0.08122981f, -1.56906E-08f, -0.9966954f),
                                Up = new RealVector3d(0.9966954f, -2.166811E-07f, 0.08122981f),
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
                                Position = new RealPoint3d(8.37547f, -4.141756f, -22.72074f),
                                Forward = new RealVector3d(0.02983941f, -0.0262746f, -0.9992093f),
                                Up = new RealVector3d(0.6153418f, -0.7872912f, 0.03907809f),
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
                                QuotaIndex = 31,
                                Position = new RealPoint3d(-0.6038378f, 1.780176f, -22.47025f),
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
                                QuotaIndex = 31,
                                Position = new RealPoint3d(-2.77109f, -20.92652f, -22.48614f),
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
                                Position = new RealPoint3d(-1.867064f, -9.528232f, -19.5139f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
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
                                QuotaIndex = 39,
                                Position = new RealPoint3d(-2.755338f, -28.30456f, -20.77414f),
                                Forward = new RealVector3d(-0.0006547411f, 0.9999998f, 0f),
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
                                QuotaIndex = 39,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-2.755337f, -28.30457f, -20.77412f),
                                Forward = new RealVector3d(-0.0006553371f, 0.9999998f, 0f),
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
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 40,
                                Position = new RealPoint3d(-2.828761f, -24.52066f, -22.75974f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 40,
                                Position = new RealPoint3d(-0.8817012f, 5.853057f, -22.75984f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 48,
                                Position = new RealPoint3d(-0.8817012f, 5.853057f, -22.75984f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 48,
                                Position = new RealPoint3d(-2.828761f, -24.52066f, -22.75974f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-2.755319f, -28.30453f, -20.7834f),
                                Forward = new RealVector3d(-0.0006553371f, 0.9999998f, 0f),
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-2.755319f, -28.30453f, -20.7834f),
                                Forward = new RealVector3d(-0.0006553371f, 0.9999998f, 0f),
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
                                Position = new RealPoint3d(-1.22244f, 11.0103f, -20.77183f),
                                Forward = new RealVector3d(-0.4945999f, -0.8691208f, 0f),
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
                                Position = new RealPoint3d(0.1455861f, 12.05235f, -20.97013f),
                                Forward = new RealVector3d(0.3973459f, -0.9176689f, 0f),
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
                                Position = new RealPoint3d(0.6056108f, 11.71095f, -20.95479f),
                                Forward = new RealVector3d(0.2144145f, -0.9767427f, 0f),
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
                                Position = new RealPoint3d(0.04746132f, 10.97257f, -20.76829f),
                                Forward = new RealVector3d(0.2519374f, -0.9677436f, 0f),
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
                                Position = new RealPoint3d(-1.843322f, 11.71887f, -20.97255f),
                                Forward = new RealVector3d(-0.2009112f, -0.9796095f, 0f),
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
                                Position = new RealPoint3d(-4.884571f, -30.94179f, -20.98564f),
                                Forward = new RealVector3d(-0.9142295f, 0.4051968f, 0f),
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
                                Position = new RealPoint3d(-2.146985f, -29.87192f, -20.78924f),
                                Forward = new RealVector3d(0.3950545f, 0.9186577f, 0f),
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
                                Position = new RealPoint3d(-3.465979f, -29.8507f, -20.78601f),
                                Forward = new RealVector3d(-0.387666f, 0.9217999f, 0f),
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
                                Position = new RealPoint3d(-3.308275f, -31.19805f, -20.98091f),
                                Forward = new RealVector3d(-0.2383991f, 0.9711673f, 0f),
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
                                Position = new RealPoint3d(-1.628053f, -30.66162f, -20.98028f),
                                Forward = new RealVector3d(0.3164066f, 0.9486237f, 0f),
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
                                Position = new RealPoint3d(-4.898768f, -24.50209f, -20.97553f),
                                Forward = new RealVector3d(-0.848234f, 0.5296217f, 0f),
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
                                Position = new RealPoint3d(-9.335197f, -33.57484f, -22.76019f),
                                Forward = new RealVector3d(-0.3198428f, 0.9474706f, 0f),
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
                                Position = new RealPoint3d(3.906856f, -33.46838f, -22.75975f),
                                Forward = new RealVector3d(0.375274f, 0.9269139f, 0f),
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
                                Position = new RealPoint3d(-0.6176838f, -24.34496f, -20.93347f),
                                Forward = new RealVector3d(0.7095101f, 0.7046952f, 0f),
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
                                Position = new RealPoint3d(-14.32078f, -24.38636f, -22.75976f),
                                Forward = new RealVector3d(0.5373609f, 0.8433524f, 0f),
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
                                Position = new RealPoint3d(-13.15699f, -25.57579f, -22.75976f),
                                Forward = new RealVector3d(0.7185488f, 0.6954765f, 0f),
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
                                Position = new RealPoint3d(-13.06201f, -20.8997f, -22.75974f),
                                Forward = new RealVector3d(0.7495389f, 0.6619603f, 0f),
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
                                Position = new RealPoint3d(-13.19266f, -16.41268f, -22.75977f),
                                Forward = new RealVector3d(0.8857695f, 0.4641253f, 0f),
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
                                Position = new RealPoint3d(-14.04146f, -19.30836f, -22.75998f),
                                Forward = new RealVector3d(0.5850915f, 0.8109673f, 0f),
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
                                Position = new RealPoint3d(-3.633968f, -23.65391f, -20.78952f),
                                Forward = new RealVector3d(-0.8602055f, 0.5099475f, 0f),
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
                                Position = new RealPoint3d(-1.882175f, -23.66453f, -20.78933f),
                                Forward = new RealVector3d(0.8888575f, 0.4581838f, 0f),
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
                                Position = new RealPoint3d(10.87576f, -6.099549f, -22.75976f),
                                Forward = new RealVector3d(-0.5148768f, 0.8572642f, 0f),
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
                                Position = new RealPoint3d(-12.16328f, 2.914898f, -22.74547f),
                                Forward = new RealVector3d(0.9999986f, -0.00163836f, 0f),
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
                                Position = new RealPoint3d(-13.12887f, 1.833694f, -22.75957f),
                                Forward = new RealVector3d(-0.2105057f, -0.9775926f, 0f),
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
                                Position = new RealPoint3d(-13.15865f, 4.201604f, -22.74594f),
                                Forward = new RealVector3d(-0.2105057f, -0.9775926f, 0f),
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
                                Position = new RealPoint3d(0.469513f, 4.967906f, -20.75679f),
                                Forward = new RealVector3d(0.9169276f, -0.3990535f, 0f),
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
                                Position = new RealPoint3d(-2.731118f, 5.620494f, -20.95719f),
                                Forward = new RealVector3d(-0.9199696f, -0.3919899f, 0f),
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
                                Position = new RealPoint3d(-1.732218f, 4.915439f, -20.76443f),
                                Forward = new RealVector3d(-0.9568917f, -0.2904449f, 0f),
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
                                Position = new RealPoint3d(-6.997502f, 14.35843f, -22.77617f),
                                Forward = new RealVector3d(-0.3945147f, -0.9188896f, 0f),
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
                                Position = new RealPoint3d(6.007345f, 14.60017f, -22.75977f),
                                Forward = new RealVector3d(0.1461517f, -0.9892622f, 0f),
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
                                Position = new RealPoint3d(9.885856f, 6.895791f, -22.75986f),
                                Forward = new RealVector3d(-0.816538f, -0.5772916f, 0f),
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
                                Position = new RealPoint3d(9.815642f, 4.721029f, -22.75985f),
                                Forward = new RealVector3d(-0.01481674f, -0.9998902f, 0f),
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
                                Position = new RealPoint3d(10.05537f, 2.306305f, -22.75984f),
                                Forward = new RealVector3d(-0.8777547f, -0.4791103f, 0f),
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
                                Position = new RealPoint3d(11.18402f, 1.020416f, -22.75996f),
                                Forward = new RealVector3d(-0.5476003f, -0.83674f, 0f),
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
                                Position = new RealPoint3d(9.895086f, -1.845164f, -22.75982f),
                                Forward = new RealVector3d(-0.9208192f, -0.3899897f, 0f),
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
                                Position = new RealPoint3d(-0.6559937f, -30.87049f, -20.96812f),
                                Forward = new RealVector3d(0.9073294f, 0.4204205f, 0f),
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
                                Position = new RealPoint3d(-1.342799f, 12.05718f, -20.95612f),
                                Forward = new RealVector3d(-0.3845664f, -0.9230974f, 0f),
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
                                Position = new RealPoint3d(10.05395f, -4.916891f, -22.75976f),
                                Forward = new RealVector3d(-0.7997059f, 0.600392f, 0f),
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
                                Position = new RealPoint3d(11.16451f, -3.458786f, -22.75977f),
                                Forward = new RealVector3d(-0.8594575f, -0.5112072f, 0f),
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
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-13.3882f, 2.986301f, -22.72948f),
                                Forward = new RealVector3d(-0.0170564f, -0.9998545f, 0f),
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
                                QuotaIndex = 47,
                                Position = new RealPoint3d(10.6249f, -20.07936f, -22.71478f),
                                Forward = new RealVector3d(-0.1174603f, 0.9930776f, 0f),
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
                                QuotaIndex = 34,
                                Position = new RealPoint3d(-13.15721f, -12.94872f, -22.75974f),
                                Forward = new RealVector3d(0.7459395f, -0.6660137f, 0f),
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
                                Position = new RealPoint3d(-13.66116f, -12.07304f, -22.75978f),
                                Forward = new RealVector3d(0.5885837f, -0.8084363f, 0f),
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
                                QuotaIndex = 45,
                                Position = new RealPoint3d(10.6249f, -20.07936f, -22.71478f),
                                Forward = new RealVector3d(-0.1174603f, 0.9930776f, 0f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-13.3882f, 2.986301f, -22.72948f),
                                Forward = new RealVector3d(-0.0170564f, -0.9998545f, 0f),
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-13.3882f, 2.986301f, -22.72948f),
                                Forward = new RealVector3d(-0.0170564f, -0.9998545f, 0f),
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(10.6249f, -20.07936f, -22.71478f),
                                Forward = new RealVector3d(-0.1174603f, 0.9930776f, 0f),
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
                                QuotaIndex = 35,
                                Position = new RealPoint3d(-2.755337f, -28.30457f, -20.77412f),
                                Forward = new RealVector3d(-0.0006553371f, 0.9999998f, 0f),
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
                                QuotaIndex = 35,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 36,
                                Position = new RealPoint3d(-2.828761f, -24.52066f, -22.75974f),
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
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 36,
                                Position = new RealPoint3d(-0.8817012f, 5.853057f, -22.75984f),
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
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-2.755337f, -28.30457f, -20.77412f),
                                Forward = new RealVector3d(-0.0006553371f, 0.9999998f, 0f),
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
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-13.3882f, 2.986301f, -22.72948f),
                                Forward = new RealVector3d(-0.0170564f, -0.9998545f, 0f),
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
                                QuotaIndex = 49,
                                Position = new RealPoint3d(10.6249f, -20.07936f, -22.71478f),
                                Forward = new RealVector3d(-0.1174603f, 0.9930776f, 0f),
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
                                QuotaIndex = 50,
                                Position = new RealPoint3d(-0.8817012f, 5.853057f, -22.75984f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 50,
                                Position = new RealPoint3d(-2.828761f, -24.52066f, -22.75974f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 30f,
                                        BoxLength = 30f,
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(-2.755337f, -28.30457f, -20.77412f),
                                Forward = new RealVector3d(-0.0006553371f, 0.9999998f, 0f),
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-2.755337f, -28.30457f, -20.77412f),
                                Forward = new RealVector3d(-0.0006553371f, 0.9999998f, 0f),
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
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-0.6848117f, 9.257743f, -20.78123f),
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
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-13.3882f, 2.986301f, -22.72948f),
                                Forward = new RealVector3d(-0.0170564f, -0.9998545f, 0f),
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
                                QuotaIndex = 51,
                                Position = new RealPoint3d(10.62463f, -20.07923f, -22.73675f),
                                Forward = new RealVector3d(-0.1174603f, 0.9930776f, 0f),
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
                                QuotaIndex = 34,
                                Position = new RealPoint3d(-2.129438f, -31.19185f, -20.97253f),
                                Forward = new RealVector3d(0.3277599f, 0.944761f, 0f),
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
                                Position = new RealPoint3d(-3.792702f, -30.7028f, -20.98432f),
                                Forward = new RealVector3d(-0.2138199f, 0.9768731f, 0f),
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
                                Position = new RealPoint3d(1.63189f, 11.90063f, -20.9667f),
                                Forward = new RealVector3d(0.9198129f, -0.3923572f, 0f),
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
                                Position = new RealPoint3d(-2.615555f, 11.97272f, -20.9679f),
                                Forward = new RealVector3d(-0.8617824f, -0.5072781f, 0f),
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
                                Position = new RealPoint3d(-14.25326f, -14.66554f, -22.66838f),
                                Forward = new RealVector3d(0.8969795f, 0.4420722f, 0f),
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
                                Position = new RealPoint3d(10.08974f, 0.2274881f, -22.75989f),
                                Forward = new RealVector3d(-0.8283696f, -0.5601819f, 0f),
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
                                Position = new RealPoint3d(-13.01511f, -18.48875f, -22.76021f),
                                Forward = new RealVector3d(0.6543007f, 0.7562345f, 0f),
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
                                QuotaIndex = 116,
                                Position = new RealPoint3d(0f, 0f, 0.05f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(9.086777f, 5.494253f, -22.75973f),
                                Forward = new RealVector3d(-0.4006021f, -0.9162521f, 0f),
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
                                Position = new RealPoint3d(-7.785954f, -2.152486f, -22.75719f),
                                Forward = new RealVector3d(0.6526739f, -0.7576389f, 0f),
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
                                Position = new RealPoint3d(-9.749521f, -3.795163f, -22.7596f),
                                Forward = new RealVector3d(0.3438003f, -0.9390428f, 0f),
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
                                Position = new RealPoint3d(3.897191f, -16.7371f, -22.71799f),
                                Forward = new RealVector3d(-0.790542f, 0.6124079f, 0f),
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
                                Position = new RealPoint3d(5.743445f, -14.96758f, -22.75976f),
                                Forward = new RealVector3d(-0.4907941f, 0.8712756f, 0f),
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
                                Position = new RealPoint3d(-3.326019f, -25.33823f, -22.75974f),
                                Forward = new RealVector3d(0.8349286f, -0.5503582f, 0f),
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
                                Position = new RealPoint3d(-2.167749f, -25.35851f, -22.75974f),
                                Forward = new RealVector3d(-0.8519661f, -0.523597f, 0f),
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
                                Position = new RealPoint3d(-3.327778f, -24.79733f, -20.79205f),
                                Forward = new RealVector3d(0.7627375f, 0.6467083f, 0f),
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
                                Position = new RealPoint3d(-2.109192f, -24.84392f, -20.7858f),
                                Forward = new RealVector3d(-0.7549677f, 0.655762f, 0f),
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
                                Position = new RealPoint3d(-0.09237849f, 5.787981f, -20.75811f),
                                Forward = new RealVector3d(-0.6906457f, -0.7231933f, 0f),
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
                                Position = new RealPoint3d(-1.231756f, 5.806184f, -20.77321f),
                                Forward = new RealVector3d(0.6950588f, -0.718953f, 0f),
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
                                Position = new RealPoint3d(1.445314f, 5.983137f, -20.96922f),
                                Forward = new RealVector3d(0.5869293f, -0.8096382f, 0f),
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
                                Position = new RealPoint3d(10.09689f, -19.33884f, -22.71478f),
                                Forward = new RealVector3d(0.1065005f, 0.9943126f, 0f),
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
                                Position = new RealPoint3d(10.6663f, -21.25878f, -22.73206f),
                                Forward = new RealVector3d(0.1065005f, 0.9943126f, 0f),
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
                                QuotaIndex = 117,
                                Position = new RealPoint3d(7.292499f, -26.09859f, -22.75972f),
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
                                QuotaIndex = 117,
                                Position = new RealPoint3d(6.615751f, -0.7557446f, -22.75983f),
                                Forward = new RealVector3d(0.06361461f, -0.9979745f, 0f),
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
                                QuotaIndex = 117,
                                Position = new RealPoint3d(-7.703213f, 0.5616345f, -22.75376f),
                                Forward = new RealVector3d(0.06361461f, -0.9979745f, 0f),
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
                                QuotaIndex = 117,
                                Position = new RealPoint3d(-8.605339f, -20.24064f, -22.75977f),
                                Forward = new RealVector3d(-0.0258968f, 0.9996646f, 0f),
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
                                QuotaIndex = 117,
                                Position = new RealPoint3d(19.10434f, -11.31516f, -20.28843f),
                                Forward = new RealVector3d(-0.9991769f, -0.04056452f, 0f),
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
                                QuotaIndex = 117,
                                Position = new RealPoint3d(-22.71873f, -9.18056f, -18.73504f),
                                Forward = new RealVector3d(0.9984882f, -0.0549656f, 0f),
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
                                QuotaIndex = 117,
                                Position = new RealPoint3d(-0.3003897f, -10.64941f, -70.08668f),
                                Forward = new RealVector3d(0.9984882f, -0.0549656f, 0f),
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
                                Position = new RealPoint3d(10.64825f, -18.79822f, -22.7332f),
                                Forward = new RealVector3d(-0.4093039f, 0.9123981f, 0f),
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
                                Position = new RealPoint3d(10.00191f, -20.90974f, -22.73209f),
                                Forward = new RealVector3d(0.1262028f, 0.9920045f, 0f),
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
                                Position = new RealPoint3d(-12.70213f, 3.739172f, -22.74589f),
                                Forward = new RealVector3d(-0.2105057f, -0.9775926f, 0f),
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
                                Position = new RealPoint3d(-12.52704f, 2.515422f, -22.75089f),
                                Forward = new RealVector3d(-0.1934837f, -0.9811035f, 0f),
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
                                Position = new RealPoint3d(-1.244148f, 6.52247f, -22.75973f),
                                Forward = new RealVector3d(0.7607677f, 0.6490242f, 0f),
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
                                Position = new RealPoint3d(-0.04587616f, 6.480059f, -22.75974f),
                                Forward = new RealVector3d(-0.7607414f, 0.6490551f, 0f),
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
                                Position = new RealPoint3d(6.174491f, -8.873768f, -22.75976f),
                                Forward = new RealVector3d(-0.9997683f, 0.02152673f, 0f),
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
                                Position = new RealPoint3d(-9.471044f, -8.903823f, -22.75977f),
                                Forward = new RealVector3d(0.9999873f, -0.005043115f, 0f),
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
                                Position = new RealPoint3d(-9.483105f, -10.36109f, -22.75977f),
                                Forward = new RealVector3d(0.9999873f, -0.005043115f, 0f),
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
                                Position = new RealPoint3d(6.016832f, -10.34509f, -22.75976f),
                                Forward = new RealVector3d(-0.9997683f, 0.02152673f, 0f),
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
                                Position = new RealPoint3d(9.514578f, -20.11513f, -22.72251f),
                                Forward = new RealVector3d(-0.9999002f, 0.01413099f, 0f),
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
                                QuotaIndex = 64,
                                Position = new RealPoint3d(9.341517f, -20.36152f, -22.75966f),
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
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 4f,
                                        BoxLength = 5.5f,
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
                                QuotaIndex = 64,
                                Position = new RealPoint3d(9.720678f, 3.449742f, -22.7598f),
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
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
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
                                QuotaIndex = 64,
                                Position = new RealPoint3d(-2.734477f, -24.03826f, -20.71867f),
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
                                        WidthRadius = 7f,
                                        BoxLength = 4f,
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
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-2.764304f, -30.46919f, -22.77867f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(-0.1611873f, -30.47577f, -22.77864f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(-5.553105f, -30.50617f, -22.77767f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(-4.545504f, -24.20475f, -22.75292f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(-0.9552863f, -24.23073f, -22.75474f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 95,
                                Position = new RealPoint3d(-1.789316f, -21.8997f, -22.75694f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(3.397027f, -30.93899f, -22.78797f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-8.960896f, -30.07776f, -22.74411f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 64,
                                Position = new RealPoint3d(-1.940565f, -9.515532f, -22.77824f),
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
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 5f,
                                        BoxLength = 5f,
                                        PositiveHeight = 4f,
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
                                QuotaIndex = 62,
                                Position = new RealPoint3d(-2.671833f, -23.25463f, -19.01647f),
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
                                QuotaIndex = 62,
                                Position = new RealPoint3d(-0.6120367f, 4.284682f, -18.99672f),
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-0.6736566f, 4.519038f, -20.73087f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-2.737994f, -23.28133f, -20.76382f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 111,
                                Position = new RealPoint3d(-4.803976f, -30.03487f, -20.98748f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 111,
                                Position = new RealPoint3d(-0.6632681f, -30.01103f, -20.98747f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 93,
                                Position = new RealPoint3d(-2.750795f, -29.12146f, -20.842f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-2.69688f, -27.73678f, -20.86346f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 65,
                                Position = new RealPoint3d(-1.326791f, -9.523492f, -22.74862f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 94,
                                Position = new RealPoint3d(-4.513432f, -21.88184f, -22.75541f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 92,
                                Position = new RealPoint3d(-2.649562f, -30.01293f, -20.97305f),
                                Forward = new RealVector3d(-1f, 1.509958E-07f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(3.397027f, -30.04367f, -22.78797f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-8.960896f, -30.96864f, -22.74411f),
                                Forward = new RealVector3d(-1f, -1.509958E-07f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-4.526499f, -20.56207f, -22.75504f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-4.0582f, -25.82853f, -20.79611f),
                                Forward = new RealVector3d(-4.371138E-08f, -1f, 5.487418E-12f),
                                Up = new RealVector3d(-0.000345267f, 2.057952E-11f, 0.9999999f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-1.361951f, -25.80803f, -20.78311f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-2.722618f, -22.37236f, -20.95359f),
                                Forward = new RealVector3d(-1f, -1.509958E-07f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-2.698647f, -25.94327f, -20.85971f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-2.687316f, -22.34196f, -19.08688f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 91,
                                Position = new RealPoint3d(-1.329686f, -23.22948f, -20.96548f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
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
                                QuotaIndex = 91,
                                Position = new RealPoint3d(-4.080126f, -23.27956f, -20.96548f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-0.9239419f, -20.55513f, -22.74847f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-3.634228f, -21.45286f, -20.95288f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(0.491353f, -20.88175f, -22.7363f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 1.509958E-07f, -1f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-5.959705f, -20.95435f, -22.75973f),
                                Forward = new RealVector3d(1.192488E-08f, 1f, -8.742278E-08f),
                                Up = new RealVector3d(0f, -8.742278E-08f, -1f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-5.060061f, -21.84846f, -20.95219f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 8.742278E-08f),
                                Up = new RealVector3d(0f, 8.742278E-08f, -1f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-1.830801f, -21.45286f, -20.95288f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-0.4371033f, -21.77939f, -20.946f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 1.509958E-07f, -1f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(0.5554637f, -25.48622f, -22.75975f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 8.742278E-08f),
                                Up = new RealVector3d(0f, -8.742278E-08f, -1f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(0.8692654f, -24.08405f, -22.75976f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-6.296547f, -24.17153f, -22.75317f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-5.910491f, -25.60023f, -22.74938f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 7.642742E-15f),
                                Up = new RealVector3d(0f, 8.742278E-08f, -1f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 92,
                                Position = new RealPoint3d(-2.78757f, -21.86394f, -19.19704f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-2.454392f, 1.631868f, -22.75976f),
                                Forward = new RealVector3d(-0.9999863f, -1.509934E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -4.572681E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(1.1551f, 1.6344f, -22.75977f),
                                Forward = new RealVector3d(-0.9999863f, -1.509934E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -4.572681E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(2.583539f, 2.025176f, -22.75977f),
                                Forward = new RealVector3d(-4.371139E-08f, -0.9999863f, 0.005230554f),
                                Up = new RealVector3d(1.790337E-10f, -0.005230554f, -0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-3.868911f, 1.951597f, -22.75975f),
                                Forward = new RealVector3d(-0.9999863f, 1.50206E-07f, 0.005230539f),
                                Up = new RealVector3d(-0.005230539f, 1.509937E-07f, -0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-2.965255f, 2.852198f, -20.96103f),
                                Forward = new RealVector3d(-0.9999863f, 1.50206E-07f, 0.005230539f),
                                Up = new RealVector3d(-0.005230539f, 1.509937E-07f, -0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(1.678731f, 2.926397f, -20.96091f),
                                Forward = new RealVector3d(-4.371139E-08f, -0.9999863f, 0.005230554f),
                                Up = new RealVector3d(1.790337E-10f, -0.005230554f, -0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-1.554941f, 2.528041f, -20.95979f),
                                Forward = new RealVector3d(-0.9999863f, -1.509917E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -7.897893E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(0.2495522f, 2.536647f, -20.95979f),
                                Forward = new RealVector3d(-0.9999863f, -1.509917E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -7.897893E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(2.901696f, 5.241633f, -22.75977f),
                                Forward = new RealVector3d(-4.371139E-08f, -0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, -0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(2.516182f, 6.673977f, -22.75977f),
                                Forward = new RealVector3d(0.9999863f, -7.897893E-10f, 0.005230539f),
                                Up = new RealVector3d(0.005230539f, 1.509937E-07f, -0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-4.239593f, 5.178794f, -22.75975f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-3.934882f, 6.585634f, -22.75976f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, 0.005230554f),
                                Up = new RealVector3d(1.790337E-10f, 0.005230554f, -0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-2.703496f, -24.1481f, -20.86444f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 81,
                                Position = new RealPoint3d(-2.720025f, -22.35528f, -20.86444f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 94,
                                Position = new RealPoint3d(-2.442381f, 2.972003f, -22.75541f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 95,
                                Position = new RealPoint3d(0.2817351f, 2.976353f, -22.75694f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(-2.506206f, 5.14258f, -22.75292f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(1.09767f, 5.14258f, -22.75292f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-0.7026165f, 3.499479f, -20.95431f),
                                Forward = new RealVector3d(-0.9999863f, -1.509917E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -7.897893E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 91,
                                Position = new RealPoint3d(0.7109039f, 4.334456f, -20.95097f),
                                Forward = new RealVector3d(-4.371139E-08f, -0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, -0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 91,
                                Position = new RealPoint3d(-2.053418f, 4.299697f, -20.95097f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 81,
                                Position = new RealPoint3d(-0.6759889f, 5.215671f, -20.84469f),
                                Forward = new RealVector3d(0.9999863f, 0.005230539f, 3.117656E-10f),
                                Up = new RealVector3d(0.005230539f, -0.9999863f, -4.371079E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-0.6562265f, 7.00939f, -20.85489f),
                                Forward = new RealVector3d(0.9999863f, 0.005230539f, 3.117656E-10f),
                                Up = new RealVector3d(0.005230539f, -0.9999863f, -4.371079E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-0.6590737f, 8.805385f, -20.85489f),
                                Forward = new RealVector3d(0.9999863f, 0.005230539f, 3.117656E-10f),
                                Up = new RealVector3d(0.005230539f, -0.9999863f, -4.371079E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-0.6590737f, 10.61979f, -20.85489f),
                                Forward = new RealVector3d(0.9999863f, 0.005230539f, 3.117656E-10f),
                                Up = new RealVector3d(0.005230539f, -0.9999863f, -4.371079E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 92,
                                Position = new RealPoint3d(-0.7563125f, 11.11036f, -20.95424f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-2.027266f, 6.90877f, -20.76319f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(0.6639923f, 6.90877f, -20.76319f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-0.6586982f, 5.218578f, -19.07031f),
                                Forward = new RealVector3d(0.9999863f, 0.005230539f, 3.117656E-10f),
                                Up = new RealVector3d(0.005230539f, -0.9999863f, -4.371079E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 92,
                                Position = new RealPoint3d(-0.6041797f, 2.954845f, -19.1616f),
                                Forward = new RealVector3d(-0.9999863f, -1.509934E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -4.572681E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(1.931901f, 11.51018f, -22.75978f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 88,
                                Position = new RealPoint3d(-3.46243f, 11.51297f, -22.76495f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-0.6666617f, 11.52242f, -22.76361f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(5.495142f, 10.95962f, -22.75978f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(5.495142f, 11.86399f, -22.75978f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-6.872357f, 11.04469f, -22.75975f),
                                Forward = new RealVector3d(-0.9999863f, -1.509934E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -4.572681E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-6.872357f, 11.94665f, -22.75975f),
                                Forward = new RealVector3d(-0.9999863f, -1.509917E-07f, -0.005230539f),
                                Up = new RealVector3d(-0.005230539f, -7.897893E-10f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 93,
                                Position = new RealPoint3d(-0.6527107f, 10.20812f, -20.81369f),
                                Forward = new RealVector3d(-4.371139E-08f, -0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, -0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 77,
                                Position = new RealPoint3d(1.450384f, 11.06664f, -20.98358f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 77,
                                Position = new RealPoint3d(-2.758185f, 11.0917f, -20.98358f),
                                Forward = new RealVector3d(0.9999863f, 0f, -0.005230539f),
                                Up = new RealVector3d(0.005230539f, 0f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(8.55089f, -21.43058f, -22.75966f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(8.557444f, -18.8552f, -22.75966f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-11.15035f, 1.641458f, -22.74763f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-11.12089f, 4.245196f, -22.75766f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 55,
                                Position = new RealPoint3d(-13.02513f, -15.23308f, -22.75977f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 55,
                                Position = new RealPoint3d(-12.96049f, -19.48505f, -22.75977f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 55,
                                Position = new RealPoint3d(9.765333f, 1.090344f, -22.75979f),
                                Forward = new RealVector3d(-1f, -1.509958E-07f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 55,
                                Position = new RealPoint3d(9.765333f, -3.045722f, -22.75979f),
                                Forward = new RealVector3d(-1f, -1.509958E-07f, 0f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(5.378044f, 10.03084f, -21.86346f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(-6.710648f, 10.54949f, -21.78379f),
                                Forward = new RealVector3d(-1f, -3.821371E-15f, 8.742278E-08f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(-8.839676f, -29.14221f, -21.93286f),
                                Forward = new RealVector3d(-1f, -6.600236E-15f, 1.509958E-07f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(3.260206f, -29.57656f, -21.79404f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 64,
                                Position = new RealPoint3d(-0.7459253f, 5.604444f, -22.75966f),
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
                                        WidthRadius = 5.5f,
                                        BoxLength = 4f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = -0.5f,
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
                                Position = new RealPoint3d(-12.44326f, -12.29927f, -21.77067f),
                                Forward = new RealVector3d(4.371139E-08f, -1f, -1.311342E-07f),
                                Up = new RealVector3d(1f, 4.371139E-08f, 1.910685E-15f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 65,
                                Position = new RealPoint3d(-0.6601611f, 16.47499f, -22.7829f),
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
                                QuotaIndex = 65,
                                Position = new RealPoint3d(-11.63005f, 2.946847f, -21.56405f),
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
                                QuotaIndex = 65,
                                Position = new RealPoint3d(-1.957546f, -35.49226f, -22.75974f),
                                Forward = new RealVector3d(1f, -3.809652E-07f, -7.212244E-06f),
                                Up = new RealVector3d(7.212243E-06f, -1.751155E-06f, 1f),
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
                                QuotaIndex = 65,
                                Position = new RealPoint3d(9.077443f, -20.15165f, -21.57033f),
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
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-0.6759463f, 4.515422f, -20.73049f),
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
                                QuotaIndex = 68,
                                Position = new RealPoint3d(-0.6120367f, 4.284682f, -18.99672f),
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
                                QuotaIndex = 68,
                                Position = new RealPoint3d(-2.671833f, -23.25463f, -19.01364f),
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
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-2.73613f, -23.28233f, -20.75701f),
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
                                QuotaIndex = 66,
                                Position = new RealPoint3d(-2.685075f, -24.09191f, -22.73889f),
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
                                        WidthRadius = 2f,
                                        BoxLength = 3.5f,
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
                                QuotaIndex = 66,
                                Position = new RealPoint3d(10.8494f, -4.315289f, -22.76254f),
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
                                        BoxLength = 5f,
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
                                QuotaIndex = 66,
                                Position = new RealPoint3d(-1.94211f, -9.50059f, -22.77139f),
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
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 5f,
                                        BoxLength = 5f,
                                        PositiveHeight = 4f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 66,
                                Position = new RealPoint3d(-0.6439818f, 5.205141f, -22.75965f),
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
                                        WidthRadius = 2f,
                                        BoxLength = 3.5f,
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
                                QuotaIndex = 66,
                                Position = new RealPoint3d(-13.8045f, -13.7201f, -22.75974f),
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
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 3f,
                                        BoxLength = 5f,
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
                                QuotaIndex = 66,
                                Position = new RealPoint3d(-2.730558f, -24.0535f, -20.79068f),
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
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 7f,
                                        BoxLength = 3.75f,
                                        PositiveHeight = 1.5f,
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
                                QuotaIndex = 70,
                                Position = new RealPoint3d(-1.916804f, -9.512072f, -22.76273f),
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
                                QuotaIndex = 70,
                                Position = new RealPoint3d(0.7041916f, -32.55142f, -22.75972f),
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
                                QuotaIndex = 70,
                                Position = new RealPoint3d(-0.6140877f, 4.234029f, -18.9729f),
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
                                QuotaIndex = 70,
                                Position = new RealPoint3d(9.997254f, -20.14242f, -22.69316f),
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
                                QuotaIndex = 70,
                                Position = new RealPoint3d(-12.8498f, 2.947226f, -22.74889f),
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
                                QuotaIndex = 67,
                                Position = new RealPoint3d(-1.917718f, -9.514047f, -22.75968f),
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
                                QuotaIndex = 67,
                                Position = new RealPoint3d(-3.484473f, -32.46219f, -22.75968f),
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
                                QuotaIndex = 67,
                                Position = new RealPoint3d(1.933566f, 5.406172f, -20.91517f),
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
                                QuotaIndex = 67,
                                Position = new RealPoint3d(9.988609f, -20.12693f, -22.69924f),
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
                                QuotaIndex = 67,
                                Position = new RealPoint3d(-3.811703f, 13.90798f, -22.77281f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 68,
                                Position = new RealPoint3d(-2.493905f, -9.516844f, -22.77139f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 118,
                                Position = new RealPoint3d(21.59283f, -13.06575f, -12.0334f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 25,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.TeleporterTwoWay,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0.25f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 118,
                                Position = new RealPoint3d(54.19954f, -3.17698f, 52.11938f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
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
                                    SharedStorage = 25,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.TeleporterTwoWay,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0.25f,
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
                                Position = new RealPoint3d(-3.201896f, -10.83815f, -22.75966f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-0.5752645f, -10.83037f, -22.75969f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-3.216486f, -8.225498f, -22.75967f),
                                Forward = new RealVector3d(0.0002440969f, 1f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-0.5834087f, -8.21334f, -22.75969f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(9.509173f, -5.681081f, -21.77433f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, -4.371139E-08f),
                                Up = new RealVector3d(-1f, -4.371139E-08f, 1.910685E-15f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(10.46752f, -7.18283f, -21.78605f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(-13.40711f, -10.82323f, -21.78534f),
                                Forward = new RealVector3d(-1f, 3.821371E-15f, -8.742278E-08f),
                                Up = new RealVector3d(0f, -1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 80,
                                Position = new RealPoint3d(6.11074f, -9.527208f, -22.77139f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 80,
                                Position = new RealPoint3d(-9.657818f, -9.527208f, -22.77139f),
                                Forward = new RealVector3d(-1f, -1.509958E-07f, 0f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(-1.892197f, -9.528879f, -23.27592f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 93,
                                Position = new RealPoint3d(-1.886913f, -9.52003f, -19.7606f),
                                Forward = new RealVector3d(-1f, 0f, -8.742278E-08f),
                                Up = new RealVector3d(8.742278E-08f, 0f, -1f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 112,
                                Position = new RealPoint3d(-5.597456f, -9.575155f, -22.77139f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 112,
                                Position = new RealPoint3d(1.740376f, -9.576949f, -22.77139f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(5.900372f, -5.556555f, -22.76724f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 94,
                                Position = new RealPoint3d(-8.202869f, -4.55682f, -22.33013f),
                                Forward = new RealVector3d(-4.371139E-08f, -4.371139E-08f, -1f),
                                Up = new RealVector3d(0f, 1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 94,
                                Position = new RealPoint3d(4.186011f, -16.10616f, -22.3227f),
                                Forward = new RealVector3d(-4.371139E-08f, -4.371139E-08f, -1f),
                                Up = new RealVector3d(0f, 1f, -4.371139E-08f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-0.6788669f, 14.06993f, -22.79828f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-1.901746f, -33.10614f, -22.76093f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(-7.99333f, -15.54707f, -22.75712f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 55,
                                Position = new RealPoint3d(-12.96049f, -24.20741f, -22.75977f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 55,
                                Position = new RealPoint3d(9.765333f, 5.502429f, -22.75979f),
                                Forward = new RealVector3d(-1f, -1.509958E-07f, 0f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 110,
                                Position = new RealPoint3d(-2.773546f, -21.12691f, -16.7117f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 109,
                                Position = new RealPoint3d(-0.6209728f, 2.04115f, -16.71171f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(-8.763407f, -23.90134f, -22.75862f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230539f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230539f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                Position = new RealPoint3d(5.549741f, 4.95999f, -22.76025f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230539f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230539f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-6.266704f, -22.37838f, -22.75976f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(0.8830256f, -22.31559f, -22.75974f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(2.906132f, 3.427694f, -22.77207f),
                                Forward = new RealVector3d(-4.371139E-08f, -0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, -0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-4.231353f, 3.412352f, -22.75862f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.9999863f, -0.005230538f),
                                Up = new RealVector3d(-3.117644E-10f, 0.005230538f, 0.9999863f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 111,
                                Position = new RealPoint3d(-3.817968f, -16.14497f, -22.76142f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 77,
                                Position = new RealPoint3d(-1.673276f, -2.77552f, -22.76142f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 77,
                                Position = new RealPoint3d(0.5621892f, -2.768243f, -22.76142f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 111,
                                Position = new RealPoint3d(-1.673276f, -16.14497f, -22.76142f),
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
                                    SpawnTime = 30,
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
                                QuotaIndex = 119,
                                Position = new RealPoint3d(6.721856f, -138.5769f, -7.255531f),
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
                                QuotaIndex = 120,
                                Position = new RealPoint3d(3.793514f, -138.314f, -7.255529f),
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
                                QuotaIndex = 121,
                                Position = new RealPoint3d(1.050504f, -138.1904f, -7.255529f),
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
                                QuotaIndex = 122,
                                Position = new RealPoint3d(-1.885601f, -138.162f, -7.255528f),
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
                                QuotaIndex = 123,
                                Position = new RealPoint3d(-4.459063f, -137.9917f, -7.255528f),
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
                                QuotaIndex = 124,
                                Position = new RealPoint3d(-18.19889f, -137.0777f, -7.255529f),
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
                                QuotaIndex = 125,
                                Position = new RealPoint3d(-20.5597f, -136.8985f, -7.255527f),
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
                                QuotaIndex = 126,
                                Position = new RealPoint3d(-23.14383f, -136.2175f, -7.255528f),
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
                                QuotaIndex = 127,
                                Position = new RealPoint3d(-26.5145f, -135.3431f, -7.255528f),
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
                                QuotaIndex = 128,
                                Position = new RealPoint3d(-30.19386f, -134.206f, -7.255527f),
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
                        },
                        ObjectTypeStartIndex = new short[16]
                        {
                            -1, 0, 14, 31, -1, -1, -1, 47, -1, -1, 
                            -1, 162, -1, -1, -1, 0, 
                        },
                        Quotas = new VariantDataObjectQuota[256]
                        {
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 4,
                                Cost = 20f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\weapons\turret\machinegun_turret\machinegun_turret").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 6f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 8,
                                Cost = 10f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\banshee\banshee").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 20f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 15f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\brute_chopper\brute_chopper").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 4,
                                Cost = 20f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 16,
                                PlacedOnMap = 6,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
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
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\turret\missile_pod\missile_pod").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 3,
                                Cost = 6f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 2,
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
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer").Index,
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
                                MaximumCount = 3,
                                PlacedOnMap = 2,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
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
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\turret\missile_pod\missile_pod").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 3,
                                Cost = 6f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 32,
                                Cost = 1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 8,
                                MaxAllowed = 32,
                                Cost = 1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\tripmine_equipment\tripmine_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_red\powerup_red").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_blue\powerup_blue").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_yellow\powerup_yellow").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\regenerator_equipment\regenerator_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\gravlift_equipment\gravlift_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 1,
                                MaxAllowed = 4,
                                Cost = 2f,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 100,
                                PlacedOnMap = 73,
                                MaxAllowed = 100,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_at_home_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_away_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\infection\infection_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\infection\infection_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\koth\koth_respawn_zone").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_respawn_zone").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\vip\vip_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\vip\vip_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_pyr_corner\sand_pyr_corner").Index,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 8,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_pyr_bridge\sand_pyr_bridge").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_gatehouse\sand_gatehouse").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 6,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block\sand_block").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_flat\sand_block_flat").Index,
                                MinimumCount = 0,
                                MaximumCount = 5,
                                PlacedOnMap = 5,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_large\sand_block_large").Index,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 8,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_ramp\sand_block_ramp").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_ramp\sand_ramp").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
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
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\industrial\pallet_large\pallet_large").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 5f,
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
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\oddball\oddball_ball_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
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
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\vip\vip_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 12,
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
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\juggernaut\juggernaut_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\fusion_coil\fusion_coil").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 32,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\teleporter_reciever\teleporter_reciever").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_wittle\sand_block_wittle").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_bridge\sand_bridge").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_column_short\sand_column_short").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 4,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_column_tt\sand_column_tt").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder\sand_cylinder").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_mast_house\sand_mast_house").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall\sand_wall").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 40,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_halfdoor\sand_wall_halfdoor").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_lowdoor\sand_wall_lowdoor").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_lsection\sand_wall_lsection").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_slit\sand_wall_slit").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_tsection\sand_wall_tsection").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_cube\sand_large_cube").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 40,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_cubex2\sand_large_cubex2").Index,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 8,
                                MaxAllowed = 40,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_small_cuberamp\sand_small_cuberamp").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_long_cuberamp\sand_long_cuberamp").Index,
                                MinimumCount = 0,
                                MaximumCount = 14,
                                PlacedOnMap = 14,
                                MaxAllowed = 30,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_1x1_lilramp\sand_1x1_lilramp").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_2x2_lilramp\sand_2x2_lilramp").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_cube_pillar\sand_large_cube_pillar").Index,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 3,
                                MaxAllowed = 30,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_halfcube\sand_large_halfcube").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 30,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_halfcubex2\sand_large_halfcubex2").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 30,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_slant_cube\sand_slant_cube").Index,
                                MinimumCount = 0,
                                MaximumCount = 16,
                                PlacedOnMap = 16,
                                MaxAllowed = 40,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_slant_cube_corner\sand_slant_cube_corner").Index,
                                MinimumCount = 0,
                                MaximumCount = 12,
                                PlacedOnMap = 12,
                                MaxAllowed = 40,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wallx2\sand_wallx2").Index,
                                MinimumCount = 0,
                                MaximumCount = 10,
                                PlacedOnMap = 10,
                                MaxAllowed = 40,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_scaffold\sand_scaffold").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_wood_bridge\sand_large_wood_bridge").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder_end\sand_cylinder_end").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder_lturn\sand_cylinder_lturn").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder_threeway\sand_cylinder_threeway").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_archtop\sand_archtop").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_small_wood_bridge\sand_small_wood_bridge").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_pyr_corner_extender\sand_pyr_corner_extender").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\shared\man_cannon_forge\man_cannon_forge").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 15f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sandbox_light_blue\sandbox_light_blue").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 2,
                                Cost = 20f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sandbox_light_red\sandbox_light_red").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 2,
                                Cost = 20f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_column_short_red\sand_column_short_red").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 4,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\stone_column_short\stone_column_short").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 2,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\stone_column_damaged\stone_column_damaged").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 5f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\levels\dlc\sandbox\sandbox_defender\sandbox_defender").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\levels\dlc\shared\forge_ball\forge_ball").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\levels\dlc\sandbox\grid\grid").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 7,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\teleporter_2way_sandbox").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_l\box_l").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_m\box_m").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xl\box_xl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xxl\box_xxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xxxl\box_xxxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_l\wall_l").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_m\wall_m").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xl\wall_xl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xxl\wall_xxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xxxl\wall_xxxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
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