using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.MCC;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using Newtonsoft.Json;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Files
{
    class GenerateCampaignFileCommand : Command
    {
        public GameCache Cache { get; }
        public Blf CampaignBlf { get; set; }

        public GenerateCampaignFileCommand(GameCache cache)
            : base(true,

                  "GenerateCampaignFile",
                  "Generate the halo3.campaign file for the specificed map info folder",

                  "GenerateCampaignFile [MapInfo Directory]",

                  "Generate the halo3.campaign file for the specificed map info folder")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 1)
                return new TagToolError(CommandError.ArgCount);

            string fileName = $"halo3.campaign";

            DirectoryInfo mapInfoDir = args.Count > 0 ? new DirectoryInfo(args[0]) : null;
            FileInfo modInfoFile = mapInfoDir != null ? new FileInfo(Path.Combine(mapInfoDir.FullName, "ModInfo.json")) : null;
            FileInfo srcFile = mapInfoDir != null ? new FileInfo(Path.Combine(mapInfoDir.FullName, fileName)) : null;

            if (mapInfoDir != null && !srcFile.Exists && !modInfoFile.Exists)
                return new TagToolError(CommandError.FileNotFound);

            if (mapInfoDir != null && srcFile.Exists)
            {
                ReadBlf(srcFile);
            }
            else if (mapInfoDir != null && modInfoFile.Exists)
            {
                CampaignBlf = GenerateCampaignBlf(modInfoFile);
            }
            else
            {
                CampaignBlf = GenerateCampaignBlf();
            }

            if (CampaignBlf == null)
                return new TagToolError(CommandError.OperationFailed);

            if (Cache is GameCacheHaloOnline)
            {
                WriteBlf(fileName);
            }
            else if (Cache is GameCacheModPackage modCache)
            {
                WriteModBlf(modCache);
            }
            else
            {
                return new TagToolError(CommandError.CacheUnsupported);
            }

            Console.WriteLine("Done!");
            return true;
        }

        public Blf GenerateCampaignBlf()
        {
            var campaignFileBuilder = new CampaignFileBuilder(Cache) 
            {
                Name = "Halo 3",
                Description = "Finish the Fight!",
            };

            var campaignBlf = campaignFileBuilder.GenerateCampaignBlf(true);

            return campaignBlf;
        }

        public Blf GenerateCampaignBlf(FileInfo modInfoFile) 
        {
            var jsonData = File.ReadAllText(Path.Combine(modInfoFile.FullName));
            var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);

            if (modInfo.GameModContents.HasCampaign)
            {
                var campaignJsonData = File.ReadAllText(Path.Combine(modInfoFile.DirectoryName, "CampaignInfo.json"));
                var campaignInfo = JsonConvert.DeserializeObject<CampaignInfo>(campaignJsonData);

                var campaignFileBuilder = new CampaignFileBuilder(Cache)
                {
                    Name = campaignInfo.Title.ParseLocalizedString(63, "Title"),
                    Description = campaignInfo.Description.ParseLocalizedString(127, "Description"),
                };

                var campaignBlf = campaignFileBuilder.GenerateCampaignBlf(false);

                var mapInfoList = campaignInfo.GetCampaignMapInfo(modInfoFile.DirectoryName);

                if (mapInfoList != null)
                {
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
                        else if (Cache is GameCacheModPackage modCache)
                        {
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

                    singlePlayerMapIds.CopyTo(campaignBlf.Campaign.MapIds);
                }
                else 
                {
                    new TagToolWarning("Failed to resolve MapIds - Campaign Map Info List Was Empty");
                }

                return campaignBlf;
            }

            return null;
        }

        public void ReadBlf(FileInfo srcFile) 
        {
            CampaignBlf = new Blf(CacheVersion.Halo3Retail, CachePlatform.Original);

            using (var stream = srcFile.Open(FileMode.Open, FileAccess.Read))
            using (var reader = new EndianReader(stream))
            {
                CampaignBlf.Read(reader);
                CampaignBlf.ConvertBlf(Cache.Version);
            }
        }

        public void WriteBlf(string fileName) 
        {
            var destFile = new FileInfo(Path.Combine(Cache.Directory.FullName, fileName));

            using (var destStream = destFile.Create())
            using (var writer = new EndianWriter(destStream))
            {
                CampaignBlf.Write(writer);
            }
        }

        public void WriteModBlf(GameCacheModPackage modCache) 
        {
            var campaignFileStream = new MemoryStream();

            using (var writer = new EndianWriter(campaignFileStream, leaveOpen: true))
            {
                CampaignBlf.Write(writer);
            }

            modCache.SetCampaignFile(campaignFileStream);
        }
    }
}