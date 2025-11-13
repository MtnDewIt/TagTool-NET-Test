using System;
using System.Linq;
using TagTool.BlamFile.Chunks;
using TagTool.Cache;
using TagTool.Cache.HaloOnline.Headers;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile
{
    public class MapFileBuilder
    {
        private CacheVersion Version;
        private CachePlatform CachePlatform;

        /// <summary>
        /// Optional map Display Name (overrides MapInfo)
        /// </summary>
        public string MapName { get; set; }

        /// <summary>
        /// Optional map description (overrides MapInfo)
        /// </summary>
        public string MapDescription { get; set; }

        /// <summary>
        /// Optional map info (if not provided, one will be generated)
        /// </summary>
        public BlfScenario MapInfo { get; set; }

        /// <summary>
        /// Optional map variant
        /// </summary>
        public Blf MapVariant { get; set; }

        public MapFileBuilder(CacheVersion version)
        {
            Version = version;
            CachePlatform = CachePlatform.Original;

            if (!CacheVersionDetection.IsBetween(Version, CacheVersion.HaloOnlineED, CacheVersion.HaloOnline106708))
                throw new ArgumentOutOfRangeException(nameof(Version), "Cache File version not supported");
        }

        public MapFile Build(CachedTag scnrTag, Scenario scnr)
        {
            VerifyInputs(scnr);

            var scenarioName = scnrTag.Name.Split('\\').Last();

            var map = new MapFile();
            map.Version = Version;
            map.Platform = CachePlatform;
            map.EndianFormat = EndianFormat.LittleEndian;
            map.MapVersion = CacheFileVersion.HaloOnline;
            map.Header = GenerateCacheFileHeader(scnrTag, scnr, scenarioName);
            map.MapFileBlf = GenerateMapBlf(scnr, scenarioName);
            return map;
        }

        private void VerifyInputs(Scenario scnr)
        {
            if (MapInfo != null)
            {
                if (MapInfo.MapId != scnr.MapId)
                    throw new InvalidOperationException($"Map info map id did not match the scenario. {MapInfo.MapId} != {scnr.MapId}");

                if (!ValidMapInfoFlags())
                    throw new InvalidOperationException($"Map info map flags did not match the scenario. map flags: {MapInfo.MapFlags}, scenario type: {scnr.MapType}");
            }

            if (MapVariant != null)
            {
                var mapVariant = MapVariant.MapVariant.MapVariant;

                if (mapVariant.MapId != scnr.MapId)
                    throw new InvalidOperationException($"Map variant map id did not match the scenario. {mapVariant.MapId} != {scnr.MapId}");
                if (mapVariant.Metadata.MapId != scnr.MapId)
                    throw new InvalidOperationException($"Map variant metadata map id did not match the scenario. {mapVariant.MapId} != {scnr.MapId}");
            }

            bool ValidMapInfoFlags()
            {
                switch (scnr.MapType)
                {
                    case ScenarioMapType.SinglePlayer:
                        return MapInfo.MapFlags.HasFlag(BlfScenario.BlfScenarioFlags.IsCampaign);
                    case ScenarioMapType.Multiplayer:
                        return MapInfo.MapFlags.HasFlag(BlfScenario.BlfScenarioFlags.IsMultiplayer);
                    case ScenarioMapType.MainMenu:
                        return MapInfo.MapFlags.HasFlag(BlfScenario.BlfScenarioFlags.IsMainmenu);
                    default:
                        return false;
                }
            }
        }

        private CacheFileHeaderHaloOnlineED GenerateCacheFileHeader(CachedTag scnrTag, Scenario scnr, string scenarioName)
        {
            // TODO: Add dynamic versioning somehow :/
            var header = new CacheFileHeaderHaloOnlineED();

            header.HeaderSignature = new Tag("head");
            header.FooterSignature = new Tag("foot");
            header.Version = CacheFileVersion.HaloOnline;
            header.BuildNumber = CacheVersionDetection.GetBuildName(Version, CachePlatform);

            switch (scnr.MapType)
            {
                case ScenarioMapType.MainMenu:
                    header.ScenarioType = ScenarioType.MainMenu;
                    break;
                case ScenarioMapType.SinglePlayer:
                    header.ScenarioType = ScenarioType.Solo;
                    break;
                case ScenarioMapType.Multiplayer:
                    header.ScenarioType = ScenarioType.Multiplayer;
                    break;
            }

            header.Size = TagStructure.GetStructureSize(typeof(CacheFileHeaderHaloOnlineED), Version, CachePlatform);
            header.SharedCacheFileType = CacheFileSharedType.None;
            header.MapId = scnr.MapId;
            header.Name = scenarioName;
            header.TagPath = scnrTag.Name;
            header.ScenarioIndex = scnrTag.Index;
            return header;
        }

        private Blf GenerateMapBlf(Scenario scnr, string scenarioName)
        {
            var blf = new Blf(Version, CachePlatform);

            blf.StartOfFile = new BlfChunkStartOfFile()
            {
                Signature = "_blf",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkStartOfFile), Version, CachePlatform),
                MajorVersion = 1,
                MinorVersion = 2,
                ByteOrderMark = -2,
            };

            blf.EndOfFile = new BlfChunkEndOfFile()
            {
                Signature = "_eof",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), Version, CachePlatform),
                MajorVersion = 1,
                MinorVersion = 2
            };

            blf.ContentFlags |= Blf.BlfFileContentFlags.StartOfFile | Blf.BlfFileContentFlags.EndOfFile;

            blf.Scenario = MapInfo ?? GenerateMapInfo(scnr, scenarioName);
            blf.ContentFlags |= Blf.BlfFileContentFlags.Scenario;

            if (MapVariant != null)
            {
                blf.MapVariant = MapVariant.MapVariant;
                blf.MapVariantTagNames = MapVariant.MapVariantTagNames;
                blf.ContentFlags |= Blf.BlfFileContentFlags.MapVariant | Blf.BlfFileContentFlags.MapVariantTagNames;
            }

            return blf;
        }

        private BlfScenario GenerateMapInfo(Scenario scnr, string scenarioName)
        {
            var scnrBlf = new BlfScenario()
            {
                Signature = "levl",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfScenario), Version, CachePlatform),
                MajorVersion = 3,
                MinorVersion = 1
            };

            scnrBlf.MapId = scnr.MapId;

            scnrBlf.Names = new BlfScenario.NameUnicode32[12];
            for (int i = 0; i < scnrBlf.Names.Length; i++)
                scnrBlf.Names[i] = new BlfScenario.NameUnicode32() { Name = MapName ?? scenarioName.ToPascalCase() };

            scnrBlf.Descriptions = new BlfScenario.NameUnicode128[12];
            for (int i = 0; i < scnrBlf.Descriptions.Length; i++)
                scnrBlf.Descriptions[i] = new BlfScenario.NameUnicode128() { Name = MapDescription ?? "" };

            scnrBlf.ScenarioPath = scenarioName;
            scnrBlf.ImageFileBase = $"m_{scenarioName}";
            scnrBlf.MinimumDesiredPlayers = 2;
            scnrBlf.MaximumDesiredPlayers = 6;
            scnrBlf.GameEngineTeamCounts = new BlfScenario.GameEngineTeams
            {
                NoGametypeTeamCount = 0,
                CtfTeamCount = 2,
                SlayerTeamCount = 8,
                OddballTeamCount = 8,
                KingTeamCount = 8,
                SandboxTeamCount = 8,
                VipTeamCount = 8,
                JuggernautTeamCount = 8,
                TerritoriesTeamCount = 4,
                AssaultTeamCount = 2,
                InfectionTeamCount = 8,
            };

            scnrBlf.MapFlags = BlfScenario.BlfScenarioFlags.Visible | BlfScenario.BlfScenarioFlags.GeneratesFilm;
            switch (scnr.MapType)
            {
                case ScenarioMapType.MainMenu:
                    scnrBlf.MapFlags |= BlfScenario.BlfScenarioFlags.IsMainmenu;
                    break;
                case ScenarioMapType.Multiplayer:
                    scnrBlf.MapFlags |= BlfScenario.BlfScenarioFlags.IsMultiplayer;
                    break;
                case ScenarioMapType.SinglePlayer:
                    scnrBlf.MapFlags |= BlfScenario.BlfScenarioFlags.IsCampaign;
                    break;
            }

            return scnrBlf;
        }
    }
}
