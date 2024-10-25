using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile.MCC
{
    public class CampaignBuilder
    {
        private GameCache Cache;

        public CampaignBuilder(GameCache cache) 
        {
            Cache = cache;
        }

        public void GetCampaignInfo(BlfCampaign campaignBlf, CampaignInfo campaignInfo, string modInfoPath) 
        {
            var mapInfoList = campaignInfo.GetCampaignMapInfo(modInfoPath);

            var singlePlayerMapIds = new List<int>();

            foreach (var mapInfo in mapInfoList) 
            {
                if (Cache is GameCacheHaloOnline)
                {
                    foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
                    {
                        if (scenario.Name.EndsWith(mapInfo.Key)) 
                        {
                            using (var stream = Cache.OpenCacheRead())
                            {
                                var scnr = Cache.Deserialize<Scenario>(stream, scenario);

                                if (scnr.MapType == ScenarioMapType.SinglePlayer)
                                    singlePlayerMapIds.Add(scnr.MapId);
                            }
                        }
                    }
                }
                else if (Cache is GameCacheModPackage)
                {
                    var modCache = Cache as GameCacheModPackage;

                    for (int i = 0; i < modCache.BaseModPackage.GetTagCacheCount(); i++)
                    {
                        modCache.SetActiveTagCache(i);

                        var tagCacheStream = modCache.OpenCacheRead();

                        foreach (var scenario in modCache.TagCache.FindAllInGroup("scnr"))
                        {
                            if (scenario.Name.EndsWith(mapInfo.Key)) 
                            {
                                var scnr = Cache.Deserialize<Scenario>(tagCacheStream, scenario);

                                if (scnr.MapType == ScenarioMapType.SinglePlayer)
                                    singlePlayerMapIds.Add(scnr.MapId);
                            }
                        }
                    }
                }
            }

            singlePlayerMapIds.CopyTo(campaignBlf.MapIds);
        }

        public Blf GenerateCampaign(FileInfo modInfoFile) 
        {
            var jsonData = File.ReadAllText(Path.Combine(modInfoFile.FullName));
            var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);

            if (modInfo.GameModContents.HasCampaign) 
            {
                var campaignJsonData = File.ReadAllText(Path.Combine(modInfoFile.DirectoryName, "CampaignInfo.json"));
                var campaignInfo = JsonConvert.DeserializeObject<CampaignInfo>(campaignJsonData);

                var campaignFileBuilder = new CampaignFileBuilder(Cache);
                campaignFileBuilder.Name = campaignInfo.Title.Neutral;
                campaignFileBuilder.Description = campaignInfo.Description.Neutral;

                var campaignBlf = campaignFileBuilder.GenerateCampaignBlf(false);

                GetCampaignInfo(campaignBlf.Campaign, campaignInfo, modInfoFile.DirectoryName);

                return campaignBlf;
            }

            return null;
        }
    }
}
