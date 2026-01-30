using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile.MCC;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile
{
    public class CampaignFileGenerator
    {
        public static void GenerateCampaignFile(GameCache cache, FileInfo mapInfo, FileInfo modInfo)
        {
            string fileName = $"halo3.campaign";
            Blf campaignBlf = null;

            if (mapInfo.Exists)
            {
                campaignBlf = ReadBlf(cache, mapInfo);
            }
            else if (modInfo.Exists)
            {
                campaignBlf = GenerateCampaignBlf(cache, modInfo);
            }
            else
            {
                campaignBlf = GenerateCampaignBlf(cache);
            }

            if (campaignBlf == null)
            {
                new TagToolError(CommandError.OperationFailed);
                return;
            }

            if (cache is GameCacheHaloOnline)
            {
                WriteBlf(cache, campaignBlf, fileName);
            }
            else if (cache is GameCacheModPackage modCache)
            {
                WriteModBlf(modCache, campaignBlf);
            }
            else
            {
                new TagToolError(CommandError.CacheUnsupported);
                return;
            }
        }

        public static void GenerateCampaignFile(GameCache cache, GameCache blamCache)
        {
            FileInfo mapInfo = blamCache.Directory != null ? new FileInfo(Path.Combine(blamCache.Directory.FullName, "info")) : null;
            FileInfo modInfo = blamCache.Directory != null ? new FileInfo(Path.Combine(Directory.GetParent(blamCache.Directory.FullName).FullName, "ModInfo.json")) : null;

            GenerateCampaignFile(cache, mapInfo, modInfo);
        }

        public static Blf GenerateCampaignBlf(GameCache cache)
        {
            var campaignFileBuilder = new CampaignFileBuilder(cache)
            {
                CampaignName = "Halo 3",
                CampaignDescription = "Finish the Fight!",
            };

            var campaignBlf = campaignFileBuilder.GenerateCampaignBlf(true);

            return campaignBlf;
        }

        public static Blf GenerateCampaignBlf(GameCache cache, FileInfo modInfoFile)
        {
            var jsonData = File.ReadAllText(Path.Combine(modInfoFile.FullName));
            var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);

            if (modInfo.GameModContents.HasCampaign)
            {
                var campaignJsonData = File.ReadAllText(Path.Combine(modInfoFile.DirectoryName, "CampaignInfo.json"));
                var campaignInfo = JsonConvert.DeserializeObject<CampaignInfo>(campaignJsonData);

                var campaignFileBuilder = new CampaignFileBuilder(cache)
                {
                    CampaignName = campaignInfo.Title?.ParseLocalizedString(63, "Title"),
                    CampaignDescription = campaignInfo.Description?.ParseLocalizedString(127, "Description"),
                };

                var campaignBlf = campaignFileBuilder.GenerateCampaignBlf(false);

                var mapInfoList = campaignInfo.GetCampaignMapInfo(modInfoFile.DirectoryName);

                if (mapInfoList != null)
                {
                    var singlePlayerMapIds = new List<int>();

                    foreach (var mapInfo in mapInfoList)
                    {
                        if (cache is GameCacheHaloOnline)
                        {
                            foreach (var scenario in cache.TagCache.FindAllInGroup("scnr"))
                            {
                                if (scenario.Name.EndsWith(mapInfo.Key))
                                {
                                    using (var stream = cache.OpenCacheRead())
                                    {
                                        var scnr = cache.Deserialize<Scenario>(stream, scenario);

                                        if (scnr.MapType == ScenarioMapType.SinglePlayer)
                                            singlePlayerMapIds.Add(scnr.MapId);
                                    }
                                }
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
                                    if (scenario.Name.EndsWith(mapInfo.Key))
                                    {
                                        var scnr = modCache.Deserialize<Scenario>(tagCacheStream, scenario);

                                        if (scnr.MapType == ScenarioMapType.SinglePlayer)
                                            singlePlayerMapIds.Add(scnr.MapId);
                                    }
                                }
                            }
                        }
                    }

                    singlePlayerMapIds.CopyTo(campaignBlf.Campaign.MapIds);
                }
                else
                {
                    Log.Warning("Failed to resolve MapIds - Campaign Map Info List Was Empty");
                }

                return campaignBlf;
            }

            return null;
        }

        public static Blf ReadBlf(GameCache cache, FileInfo srcFile)
        {
            Blf campaignBlf = new Blf(CacheVersion.Halo3Retail, CachePlatform.Original);

            using (var stream = srcFile.Open(FileMode.Open, FileAccess.Read))
            using (var reader = new EndianReader(stream))
            {
                campaignBlf.Read(reader);
                campaignBlf.ConvertBlf(cache.Version);
            }

            return campaignBlf;
        }

        public static void WriteBlf(GameCache cache, Blf campaignBlf, string fileName)
        {
            var destFile = new FileInfo(Path.Combine(cache.Directory.FullName, fileName));

            using (var destStream = destFile.Create())
            using (var writer = new EndianWriter(destStream))
            {
                campaignBlf.Write(writer);
            }
        }

        public static void WriteModBlf(GameCacheModPackage modCache, Blf campaignBlf)
        {
            var campaignFileStream = new MemoryStream();

            using (var writer = new EndianWriter(campaignFileStream, leaveOpen: true))
            {
                campaignBlf.Write(writer);
            }

            modCache.SetCampaignFile(campaignFileStream);
        }
    }
}