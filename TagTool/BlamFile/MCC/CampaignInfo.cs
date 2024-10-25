using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class CampaignInfo : TagStructure
    {
        public Guid CampaignGuid;
        public LocalizedString Title;
        public LocalizedString Description;
        public List<string> CampaignMaps;

        public Dictionary<string, object> GetCampaignMapInfo(string path)
        {
            var mapInfoTable = new Dictionary<string, object>();

            if (CampaignMaps != null)
            {
                foreach (var map in CampaignMaps)
                {
                    var mapInfo = File.ReadAllText(Path.Combine(path, map));
                    var campaignMapInfo = JsonConvert.DeserializeObject<CampaignMapInfo>(mapInfo);
                    var campaignMapName = campaignMapInfo.ScenarioFile.Split("/").Last();

                    mapInfoTable.Add(campaignMapName, campaignMapInfo);
                }
            }

            return mapInfoTable;
        }
    }
}