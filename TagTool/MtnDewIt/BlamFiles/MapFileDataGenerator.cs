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
                case CacheVersion.HaloOnlineEDLegacy:
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

            if (Version >= CacheVersion.HaloOnlineEDLegacy)
            {
                headerData.Unknown1 = true;
                headerData.TrackedBuild = true;
                headerData.HasInsertionPoints = false;
                headerData.SharedFileFlags = 62;
                headerData.CreationTime = new LastModificationDate
                {
                    Low = 1497946735,
                    High = 30434076,
                };

                if (Version >= CacheVersion.HaloOnline235640)
                {
                    headerData.SharedFileTimes = new LastModificationDate[8];
                }
                else 
                {
                    headerData.SharedFileTimes = new LastModificationDate[6]
                    {
                        // Data is pulled from MS23 guardian.map (its used for all the MS30 maps in 0.6)
                        new LastModificationDate
                        {
                            Low = 3430487812,
                            High = 30434075,
                        },
                        new LastModificationDate
                        {
                            Low = 3432157979,
                            High = 30434075,
                        },
                        new LastModificationDate
                        {
                            Low = 3432157979,
                            High = 30434075,
                        },
                        new LastModificationDate
                        {
                            Low = 3432157979,
                            High = 30434075,
                        },
                        new LastModificationDate
                        {
                            Low = 3432157979,
                            High = 30434075,
                        },
                        new LastModificationDate
                        {
                            Low = 3432157979,
                            High = 30434075,
                        },
                    };
                }

                headerData.MinorVersion = -1;
                headerData.Reports = new SectionFileBounds
                {
                    Offset = 13200,
                    Size = 326784,
                };
                headerData.Author = new FileAuthor
                {
                    Data = CacheFileHeaderData.SetAuthor("builder"),
                };
                headerData.Unknown4 = new byte[16]
                {
                    0x00, 0x00, 0x00, 0x00, 0xF4, 0x17, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                };
                headerData.Unknown5 = 1693369567698058236;
                headerData.Hash = new NetworkRequestHash
                {
                    // Data is pulled from MS23 guardian.map (its used for all the MS30 maps in 0.6)
                    Data = new uint[5]
                    {
                        1961340354, 592528155, 1389252821, 3333181734, 1566121884,
                    },
                };
                headerData.RSASignature = new RSASignature
                {
                    // Data is pulled from MS23 guardian.map (its used for all the MS30 maps in 0.6)
                    Data = new ulong[32]
                    {
                        1364809335882665978, 18269941122795469082, 2319919015463633988, 13969155041126813317, 17749661851250191155, 14491492943073825341, 11596070317558956623, 9760198012812704706, 9634784248627116922, 1404523416097737799,
                        9307505579238429194, 10455571150539799640, 7613048112384907601, 17000443677961962225, 11380724319532577381, 17286549536402711991, 12546782975187070652, 17110958633532790604, 873542523889005935, 979720889357273377,
                        15310101141997071761, 656951351936697696, 11251395024336835301, 12426984508257679424, 17356562460000330802, 17485407345886496508, 11999317062900749281, 9944307177821876249, 15561861088235611244, 13950092135888117847,
                        11407002650072343604, 5738198808858687009,
                    },
                };
                headerData.SectionOffsets = new int[4]
                {
                    0, 0, 0, 0,
                };
                headerData.OriginalSectionBounds = new SectionFileBounds[4]
                {
                    new SectionFileBounds
                    {
                        Offset = 13200,
                        Size = 326784,
                    },
                    new SectionFileBounds
                    {
                        Offset = 13200,
                        Size = 0,
                    },
                    new SectionFileBounds
                    {
                        Offset = 13200,
                        Size = 0,
                    },
                    new SectionFileBounds
                    {
                        Offset = -1,
                        Size = 0,
                    },
                };
            }

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

            if (Version == CacheVersion.HaloOnlineEDLegacy)
            {
                mapInfo.Length = (int)TagStructure.GetStructureSize(typeof(BlfDataScenario), CacheVersion.Halo3Retail, CachePlatform);
                mapInfo.MajorVersion = 0;
                mapInfo.MinorVersion = 0;
            }

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

            if (Version == CacheVersion.HaloOnlineEDLegacy)
            {
                mapInfo.Insertions = new BlfDataScenarioInsertion[8];
            }
            else 
            {
                mapInfo.Insertions = new BlfDataScenarioInsertion[9];
            }

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
            if (Version == CacheVersion.HaloOnlineEDLegacy)
            {
                mapInfo.Length = (int)TagStructure.GetStructureSize(typeof(BlfDataScenario), CacheVersion.Halo3Retail, CachePlatform);
                mapInfo.MajorVersion = 0;
                mapInfo.MinorVersion = 0;
            }

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