using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

                var jsonObject = JObject.Parse(jsonData);

                if (jsonObject.ContainsKey("Flags") && jsonObject.ContainsKey("MaximumTeamsByGameCategory"))
                {
                    var multiplayerMapInfo = JsonConvert.DeserializeObject<MultiplayerMapInfo>(jsonData);

                    MapFile.Blf.Scenario.ScenarioPath = multiplayerMapInfo.ScenarioFile;
                    MapFile.Blf.Scenario.ImageFileBase = $"m_{multiplayerMapInfo.ScenarioFile.Split('\\').Last()}";

                    if (multiplayerMapInfo.Flags.Contains(BlamFile.MCC.MapFlags.ForgeMap))
                        MapFile.Blf.Scenario.MapFlags |= BlfScenarioFlags.IsForgeOnly;

                    var parsedTitle = ValidateUnicodeString(multiplayerMapInfo.Title, 32, $@"Title");
                    var parsedDescription = ValidateUnicodeString(multiplayerMapInfo.Description, 128, $@"Description");

                    for (int i = 0; i < MapFile.Blf.Scenario.Names.Length; i++) 
                        MapFile.Blf.Scenario.Names[i].Name = parsedTitle;

                    for (int i = 0; i < MapFile.Blf.Scenario.Descriptions.Length; i++) 
                        MapFile.Blf.Scenario.Descriptions[i].Name = parsedDescription;

                    MapFile.Blf.Scenario.GameEngineTeamCounts.NoGametypeTeamCount = 0;
                    MapFile.Blf.Scenario.GameEngineTeamCounts.CtfTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_CTF];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.SlayerTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Slayer];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.OddballTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Oddball];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.KingTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_KOTH];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.SandboxTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Sandbox];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.VipTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_VIP];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.JuggernautTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Juggernaut];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.TerritoriesTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Territories];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.AssaultTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Assault];
                    MapFile.Blf.Scenario.GameEngineTeamCounts.InfectionTeamCount = multiplayerMapInfo.MaximumTeamsByGameCategory[GameCategoryIndex.GameCategory_Infection];
                }
                else if (jsonObject.ContainsKey("CampaignMapKind") && jsonObject.ContainsKey("CampaignMetagame"))
                {
                    var campaignMapInfo = JsonConvert.DeserializeObject<CampaignMapInfo>(jsonData);

                    MapFile.Blf.Scenario.ScenarioPath = campaignMapInfo.ScenarioFile;
                    MapFile.Blf.Scenario.ImageFileBase = $"m_{campaignMapInfo.ScenarioFile.Split('\\').Last()}";

                    var parsedTitle = ValidateUnicodeString(campaignMapInfo.Title, 32, $@"Title");
                    var parsedDescription = ValidateUnicodeString(campaignMapInfo.Description, 128, $@"Description");

                    for (int i = 0; i < MapFile.Blf.Scenario.Names.Length; i++)
                        MapFile.Blf.Scenario.Names[i].Name = parsedTitle;

                    for (int i = 0; i < MapFile.Blf.Scenario.Descriptions.Length; i++)
                        MapFile.Blf.Scenario.Descriptions[i].Name = parsedDescription;

                    ParseInsertionPoints(campaignMapInfo.InsertionPoints);
                }
                else if (jsonObject.ContainsKey("MapDefaultPrimaryWeapon") && !jsonObject.ContainsKey("MapDefaultPrimaryWeaponForge"))
                {
                    var firefightMapInfo = JsonConvert.DeserializeObject<FirefightMapInfo>(jsonData);

                    MapFile.Blf.Scenario.ScenarioPath = firefightMapInfo.ScenarioFile;
                    MapFile.Blf.Scenario.ImageFileBase = $"m_{firefightMapInfo.ScenarioFile.Split('\\').Last()}";

                    var parsedTitle = ValidateUnicodeString(firefightMapInfo.Title, 32, $@"Title");
                    var parsedDescription = ValidateUnicodeString(firefightMapInfo.Description, 128, $@"Description");

                    for (int i = 0; i < MapFile.Blf.Scenario.Names.Length; i++)
                        MapFile.Blf.Scenario.Names[i].Name = parsedTitle;

                    for (int i = 0; i < MapFile.Blf.Scenario.Descriptions.Length; i++)
                        MapFile.Blf.Scenario.Descriptions[i].Name = parsedDescription;

                    ParseInsertionPoints(firefightMapInfo.InsertionPoints);
                }
                else
                {
                    throw new InvalidOperationException("Invalid JSON structure");
                }
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

        public string ValidateUnicodeString(LocalizedString input, int length, string errorMessage) 
        {
            var terminatedLength = length - 1;

            if (input.Neutral.Length > terminatedLength)
            {
                var output = $@"string length exceeded supported value [{input.Neutral.Length} > {terminatedLength}]. Extra characters have been removed";
                new TagToolWarning(errorMessage != null ? $@"{errorMessage} {output}" : output);

                return input.Neutral.Remove(terminatedLength);
            }
            else 
            {
                return input.Neutral;
            }
        }

        public void ParseInsertionPoints(List<InsertionPointInfo> insertionPoints) 
        {
            for (int i = 0; i < insertionPoints.Count; i++)
            {
                MapFile.Blf.Scenario.Insertions[i].ZoneSetIndex = (short)insertionPoints[i].ZoneSetIndex;
                MapFile.Blf.Scenario.Insertions[i].Visible = insertionPoints[i].Valid;

                if (insertionPoints[i].ODST != null) 
                {
                    if (insertionPoints[i].ODST.IsFirefight)
                        MapFile.Blf.Scenario.Insertions[i].Flags |= BlfScenarioInsertion.BlfScenarioInsertionFlags.SurvivalBit;

                    //MapFile.Blf.Scenario.Insertions[i].ReturnFromMapId = GetMapIdFromGuid(insertionPoints[i].ODST.ReturnFromMapGuid);
                }

                var parsedInsertionTitle = ValidateUnicodeString(insertionPoints[i].Title, 32, $@"Insertion Point {i} Title");
                var parsedInsertionDescription = ValidateUnicodeString(insertionPoints[i].Description, 128, $@"Insertion Point {i} Description");

                for (int j = 0; j < MapFile.Blf.Scenario.Names.Length; j++)
                    MapFile.Blf.Scenario.Insertions[i].Names[j].Name = parsedInsertionTitle;

                for (int j = 0; j < MapFile.Blf.Scenario.Descriptions.Length; j++)
                    MapFile.Blf.Scenario.Insertions[i].Descriptions[j].Name = parsedInsertionDescription;
            }
        }
    }
}
