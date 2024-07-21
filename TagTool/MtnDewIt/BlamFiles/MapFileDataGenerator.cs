using System;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.BlamFiles
{
    public class MapFileDataGenerator
    {
        private CacheVersion Version;
        private CachePlatform CachePlatform;

        public string MapName { get; set; }
        public string MapDescription { get; set; }
        public BlfDataScenario MapInfo { get; set; }
        public BlfData MapVariant { get; set; }

        public MapFileDataGenerator(CacheVersion version)
        {
            Version = version;
            CachePlatform = CachePlatform.Original;

            if (!CacheVersionDetection.IsBetween(Version, CacheVersion.HaloOnlineED, CacheVersion.HaloOnline700123))
                throw new ArgumentOutOfRangeException(nameof(Version), "Cache File version not supported");
        }

        public MapFileData BuildMap(CachedTag scnrTag, Scenario scnr)
        {
            var scenarioName = scnrTag.Name.Split('\\').Last();

            var mapFile = new MapFileData();
            mapFile.Version = Version;
            mapFile.CachePlatform = CachePlatform;
            mapFile.EndianFormat = EndianFormat.LittleEndian;
            mapFile.MapVersion = CacheFileVersion.HaloOnline;
            mapFile.Header = GenerateCacheFileHeaderData(scnrTag, scnr, scenarioName);
            mapFile.MapFileBlf = GenerateBlfData(scnr, scenarioName);

            return mapFile;
        }

        private CacheFileHeaderDataHaloOnline GenerateCacheFileHeaderData(CachedTag scnrTag, Scenario scnr, string scenarioName)
        {
            var headerData = new CacheFileHeaderDataHaloOnline();
            headerData.HeaderSignature = new Tag("head");
            headerData.FooterSignature = new Tag("foot");
            headerData.FileVersion = CacheFileVersion.HaloOnline;

            switch (Version) 
            {
                case CacheVersion.HaloOnline106708:
                    headerData.FileLength = 339984;
                    break;
                default:
                    headerData.FileLength = (int)TagStructure.GetStructureSize(typeof(CacheFileHeaderGenHaloOnline), Version, CachePlatform);
                    break;
            }

            headerData.Build = CacheVersionDetection.GetBuildName(Version, CachePlatform);

            switch (scnr.MapType)
            {
                case ScenarioMapType.MainMenu:
                    headerData.CacheType = CacheFileType.MainMenu;
                    break;
                case ScenarioMapType.SinglePlayer:
                    headerData.CacheType = CacheFileType.Campaign;
                    break;
                case ScenarioMapType.Multiplayer:
                    headerData.CacheType = CacheFileType.Multiplayer;
                    break;
            }

            headerData.SharedCacheType = CacheFileSharedType.None;

            headerData.MapId = scnr.MapId;
            headerData.Name = scenarioName;
            headerData.ScenarioPath = scnrTag.Name;
            headerData.ScenarioTagIndex = scnrTag.Index;

            return headerData;
        }

        private BlfData GenerateBlfData(Scenario scnr, string scenarioName)
        {
            var blfData = new BlfData(Version, CachePlatform);

            blfData.StartOfFile = new BlfDataChunkStartOfFile()
            {
                Signature = "_blf",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataChunkStartOfFile), Version, CachePlatform),
                MajorVersion = 1,
                MinorVersion = 2,
                ByteOrderMarker = -2,
            };

            blfData.EndOfFile = new BlfDataChunkEndOfFile()
            {
                Signature = "_eof",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataChunkEndOfFile), Version, CachePlatform),
                MajorVersion = 1,
                MinorVersion = 2
            };

            blfData.ContentFlags |= BlfDataFileContentFlags.StartOfFile | BlfDataFileContentFlags.EndOfFile;

            if (MapInfo == null)
            {
                blfData.Scenario = GenerateMapInfo(scnr, scenarioName);
            }
            else 
            {
                blfData.Scenario = MapInfo;
                PatchMapInfo(blfData.Scenario, scnr);
            }

            blfData.ContentFlags |= BlfDataFileContentFlags.Scenario;

            if (MapVariant != null)
            {
                blfData.MapVariant = MapVariant.MapVariant;
                blfData.ContentFlags |= BlfDataFileContentFlags.MapVariant;

                if (Version == CacheVersion.HaloOnlineED)
                {
                    blfData.MapVariantTagNames = MapVariant.MapVariantTagNames;
                    blfData.ContentFlags |= BlfDataFileContentFlags.MapVariantTagNames;
                }
            }

            return blfData;
        }

        private BlfDataScenario GenerateMapInfo(Scenario scnr, string scenarioName)
        {
            var mapInfo = new BlfDataScenario()
            {
                Signature = "levl",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataScenario), Version, CachePlatform),
                MajorVersion = 3,
                MinorVersion = 1
            };

            mapInfo.MapId = scnr.MapId;
            mapInfo.MapFlags = BlfDataScenarioFlags.GeneratesFilm;

            switch (scnr.MapType)
            {
                case ScenarioMapType.MainMenu:
                    mapInfo.MapFlags |= BlfDataScenarioFlags.IsMainmenu;
                    break;
                case ScenarioMapType.Multiplayer:
                    mapInfo.MapFlags |= BlfDataScenarioFlags.IsMultiplayer;
                    break;
                case ScenarioMapType.SinglePlayer:
                    mapInfo.MapFlags |= BlfDataScenarioFlags.IsCampaign;
                    break;
            }

            mapInfo.Names = new NameUnicode32[12];
            mapInfo.Descriptions = new NameUnicode128[12];

            for (int i = 0; i < mapInfo.Names.Length; i++)
            {
                mapInfo.Names[i] = new NameUnicode32()
                {
                    Name = MapName ?? scenarioName.ToPascalCase()
                };
            }

            for (int i = 0; i < mapInfo.Descriptions.Length; i++)
            {
                mapInfo.Descriptions[i] = new NameUnicode128()
                {
                    Name = MapDescription ?? ""
                };
            }

            mapInfo.MapName = scenarioName;
            mapInfo.ImageName = $"m_{scenarioName}";
            mapInfo.MinimumDesiredPlayers = 2;
            mapInfo.MaximumDesiredPlayers = 6;

            mapInfo.GameEngineTeamCounts = new BlfDataGameEngineTeams
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
            };

            mapInfo.AllowSavedFilms = false;

            mapInfo.Insertions = new BlfDataScenarioInsertion[9];

            for (int i = 0; i < mapInfo.Insertions.Length; i++)
            {
                mapInfo.Insertions[i] = new BlfDataScenarioInsertion() 
                {
                    Visible = false,
                };
            }

            return mapInfo;
        }

        private void PatchMapInfo(BlfDataScenario mapInfo, Scenario scnr) 
        {
            mapInfo.AllowSavedFilms = false;

            if (scnr.MapType != ScenarioMapType.SinglePlayer) 
            {
                for (int i = 0; i < mapInfo.Insertions.Length; i++)
                {
                    var insertion = mapInfo.Insertions[i];

                    insertion.Visible = false;
                }
            }
        }
    }
}