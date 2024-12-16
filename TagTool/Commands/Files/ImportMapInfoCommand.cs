﻿using Newtonsoft.Json;
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
using TagTool.Tags.Definitions;

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

                  $"Import's the specified map info data into the current {mapFile.Header.GetName()}.map file instance\n" +
                  $"Assumes that the scenario associated with the map info data exists in the cache before importing")
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

            if (file.Extension == ".json") 
            {
                var jsonData = File.ReadAllText(file.FullName);

                var jsonObject = JObject.Parse(jsonData);

                var modInfoPath = new DirectoryInfo(file.DirectoryName).Parent;

                var campaignInfoTable = ModInfo.GetCampaignInfoTable(modInfoPath.FullName);

                using (var stream = Cache.OpenCacheRead())
                {
                    var scenarioTable = CampaignInfo.GetScenarioTable(Cache, stream);

                    if (jsonObject.ContainsKey("Flags") && jsonObject.ContainsKey("MaximumTeamsByGameCategory"))
                    {
                        var multiplayerMapInfo = JsonConvert.DeserializeObject<MultiplayerMapInfo>(jsonData);

                        if (!GetScenarioDefinition(stream, multiplayerMapInfo.ScenarioFile, out var scnr))
                            return new TagToolError(CommandError.TagInvalid, $"Could not find scenario associated with \"{file.Name}\"");

                        multiplayerMapInfo.ConvertMultiplayerMapInfo(MapFile.Blf.Scenario, scnr);
                    }
                    else if (jsonObject.ContainsKey("CampaignMapKind") && jsonObject.ContainsKey("CampaignMetagame"))
                    {
                        var campaignMapInfo = JsonConvert.DeserializeObject<CampaignMapInfo>(jsonData);

                        if (!GetScenarioDefinition(stream, campaignMapInfo.ScenarioFile, out var scnr))
                            return new TagToolError(CommandError.TagInvalid, $"Could not find scenario associated with \"{file.Name}\"");

                        campaignMapInfo.ConvertCampaignMapInfo(scenarioTable, campaignInfoTable, MapFile.Blf.Scenario, scnr);
                    }
                    else if (jsonObject.ContainsKey("MapDefaultPrimaryWeapon") && !jsonObject.ContainsKey("MapDefaultPrimaryWeaponForge"))
                    {
                        var firefightMapInfo = JsonConvert.DeserializeObject<FirefightMapInfo>(jsonData);

                        if (!GetScenarioDefinition(stream, firefightMapInfo.ScenarioFile, out var scnr))
                            return new TagToolError(CommandError.TagInvalid, $"Could not find scenario associated with \"{file.Name}\"");

                        firefightMapInfo.ConvertFirefightMapInfo(scenarioTable, campaignInfoTable, MapFile.Blf.Scenario, scnr);
                    }
                    else
                    {
                        return new InvalidOperationException("Invalid JSON structure");
                    }
                }
            }

            if (file.Extension == ".mapinfo") 
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
                            return new Exception("Unexpected map info file size");
                    }
                    
                    var mapInfo = new Blf(version, CachePlatform.Original);
                    mapInfo.Read(reader);
                    mapInfo.ConvertBlf(Cache.Version);

                    MapFile.Blf.Scenario = mapInfo.Scenario;
                }
            }

            return true;
        }

        public bool GetScenarioDefinition(Stream stream, string scenarioPath, out Scenario scnr)
        {
            var scnrName = scenarioPath.Split("/").Last();

            foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr")) 
            {
                if (scenario.Name.EndsWith(scnrName)) 
                {
                    scnr = Cache.Deserialize<Scenario>(stream, scenario);
                    return true;
                }
            }

            scnr = null;
            return false;
        }
    }
}
