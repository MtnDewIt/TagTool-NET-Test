using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile.MCC
{
    public class CampaignInfo : TagStructure
    {
        public Guid CampaignGuid;
        public LocalizedString Title;
        public LocalizedString Description;
        public List<string> CampaignMaps;

        public Dictionary<string, CampaignMapInfo> GetCampaignMapInfo(string path)
        {
            if (CampaignMaps != null)
            {
                var mapInfoTable = new Dictionary<string, CampaignMapInfo>();

                foreach (var map in CampaignMaps)
                {
                    var jsonData = File.ReadAllText(Path.Combine(path, map));
                    var campaignMapInfo = JsonConvert.DeserializeObject<CampaignMapInfo>(jsonData);
                    var campaignMapName = campaignMapInfo.ScenarioFile.Split("/").Last();

                    mapInfoTable.Add(campaignMapName, campaignMapInfo);
                }

                return mapInfoTable;
            }

            return null;
        }

        public static Dictionary<string, Scenario> GetScenarioTable(GameCache cache, Stream cacheStream)
        {
            var scenarioTable = new Dictionary<string, Scenario>();

            if (cache is GameCacheHaloOnline)
            {
                foreach (var scenario in cache.TagCache.FindAllInGroup("scnr"))
                {
                    var scnr = cache.Deserialize<Scenario>(cacheStream, scenario);

                    if (scnr.MapType == ScenarioMapType.SinglePlayer)
                        scenarioTable.Add(scenario.Name, scnr);
                }
            }
            else if (cache is GameCacheModPackage modCache)
            {
                for (int i = 0; i < modCache.BaseModPackage.GetTagCacheCount(); i++)
                {
                    modCache.SetActiveTagCache(i);

                    var tagCacheStream = modCache.OpenCacheRead();

                    foreach (var scenario in modCache.TagCache.FindAllInGroup("scnr"))
                    {
                        var scnr = cache.Deserialize<Scenario>(tagCacheStream, scenario);

                        if (scnr.MapType == ScenarioMapType.SinglePlayer)
                            scenarioTable.Add(scenario.Name, scnr);
                    }
                }
            }

            return scenarioTable;
        }
    }
}