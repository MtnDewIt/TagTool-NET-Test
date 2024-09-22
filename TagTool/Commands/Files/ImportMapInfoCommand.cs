using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.HaloOnline;
using TagTool.BlamFile.MCC;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.IO;

namespace TagTool.Commands.Files
{
    class ImportMapInfoCommand : Command 
    {
        private GameCache Cache { get; }
        private HaloOnlineMapFile MapFile { get; }

        public ImportMapInfoCommand(GameCache cache, HaloOnlineMapFile mapFile)
            : base(true,
                  $"ImportMapInfo",
                  $"Import's the specified map info data into the current {mapFile.Header.GetName()}.map file instance",
                  $"ImportMapInfo <map info path>",
                  $"Import's the specified map info data into the current {mapFile.Header.GetName()}.map file instance")
        {
            Cache = cache;
            MapFile = mapFile;
        }

        public override object Execute(List<string> args) 
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            var file = new FileInfo(args[0]);

            if (!file.Exists)
                return new TagToolError(CommandError.FileNotFound);

            if (file.Name.EndsWith(".json")) 
            {
                var jsonData = File.ReadAllText(file.FullName);

                // TODO: Add support for other Excession map info types
                // There is no easy way fo telling which format a given excession file is
                // One way would be to attempt to deserialize each type, but that has its own issues

                //var campaignMapInfo = JsonConvert.DeserializeObject<CampaignMapInfo>(jsonData);
                var multiplayerMapInfo = JsonConvert.DeserializeObject<MultiplayerMapInfo>(jsonData);
                //var firefightMapInfo = JsonConvert.DeserializeObject<FirefightMapInfo>(jsonData);

                MapFile.Blf.Scenario.ScenarioPath = multiplayerMapInfo.ScenarioFile;
                MapFile.Blf.Scenario.ImageFileBase = $"m_{multiplayerMapInfo.ScenarioFile}";

                if (multiplayerMapInfo.Flags.Contains(BlamFile.MCC.MapFlags.ForgeMap))
                    MapFile.Blf.Scenario.MapFlags |= BlfScenarioFlags.IsForgeOnly;

                // TODO: Add checks to make sure that the map name and description do not exceed the max character length
                // Maybe add a warning when this does occur, and just cull the extra characters from the string
                for (int i = 0; i < MapFile.Blf.Scenario.Names.Length; i++)
                    MapFile.Blf.Scenario.Names[i].Name = multiplayerMapInfo.Title.Neutral;

                for (int i = 0; i < MapFile.Blf.Scenario.Descriptions.Length; i++)
                    MapFile.Blf.Scenario.Descriptions[i].Name = multiplayerMapInfo.Description.Neutral;

                MapFile.Blf.Scenario.GameEngineTeamCounts[0] = 0;
                MapFile.Blf.Scenario.GameEngineTeamCounts[1] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_CTF];
                MapFile.Blf.Scenario.GameEngineTeamCounts[2] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Slayer];
                MapFile.Blf.Scenario.GameEngineTeamCounts[3] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Oddball];
                MapFile.Blf.Scenario.GameEngineTeamCounts[4] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_KOTH];
                MapFile.Blf.Scenario.GameEngineTeamCounts[5] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Juggernaut];
                MapFile.Blf.Scenario.GameEngineTeamCounts[6] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Infection];
                MapFile.Blf.Scenario.GameEngineTeamCounts[7] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Sandbox];
                MapFile.Blf.Scenario.GameEngineTeamCounts[8] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_VIP];
                MapFile.Blf.Scenario.GameEngineTeamCounts[9] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Territories];
                MapFile.Blf.Scenario.GameEngineTeamCounts[10] = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Assault];
            }

            if (file.Name.EndsWith(".mapinfo")) 
            {
                using (var stream = file.OpenRead())
                using (var reader = new EndianReader(stream))
                {
                    var version = CacheVersion.Halo3Retail;

                    switch (reader.Length)
                    {
                        case 0x4E91:
                            version = CacheVersion.Halo3Retail;
                            break;
                        case 0x9A01:
                            version = CacheVersion.Halo3ODST;
                            break;
                        case 0xCDD9:
                            version = CacheVersion.HaloReach;
                            break;
                        default:
                            throw new Exception("Unexpected map info file size");
                    }
                    
                    var mapInfo = new Blf(version, CachePlatform.Original);
                    mapInfo.Read(reader);
                    mapInfo.ConvertBlf(Cache.Version);

                    MapFile.Blf.Scenario = mapInfo.Scenario;
                }
            }

            return true;
        }
    }
}
