using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Commands.Common;
using System;
using System.IO;
using TagTool.IO;
using TagTool.BlamFile;
using Newtonsoft.Json;
using TagTool.BlamFile.MCC;
using System.Linq;

namespace TagTool.Commands.Tags
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            false,
            "DebugTest",
            "Self Explanatory",

            "DebugTest",
            "Self Explanatory"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            var stream = Cache.OpenCacheRead();

            var jsonData = File.ReadAllText(Path.Combine(args[0], "ModInfo.json"));
            var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);
            var mapInfoList = modInfo.GetMapInfoList(args[0]);

            foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
            {
                foreach (var mapInfo in mapInfoList)
                {
                    if (scenario.Name.EndsWith(mapInfo.Key))
                    {
                        var scnr = Cache.Deserialize<Scenario>(stream, scenario);
                        var blfScenario = GenerateMapInfo(mapInfo.Value, scnr);

                        Console.WriteLine(blfScenario.Names[0].Name);
                    }
                }
            }

            return true;
        }

        public BlfScenario GenerateMapInfo(object mapInfo, Scenario scnr)
        {
            var scenario = new BlfScenario()
            {
                Signature = "levl",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfScenario), Cache.Version, Cache.Platform),
                MajorVersion = 3,
                MinorVersion = 1,
                Names = Enumerable.Range(0, 12).Select(x => new NameUnicode32 { Name = "" }).ToArray(),
                Descriptions = Enumerable.Range(0, 12).Select(x => new NameUnicode128 { Name = "" }).ToArray(),
            };

            switch (mapInfo)
            {
                case CampaignMapInfo campaignMapInfo:
                    campaignMapInfo.ConvertCampaignMapInfo(scenario, scnr);
                    break;

                case MultiplayerMapInfo multiplayerMapInfo:
                    multiplayerMapInfo.ConvertMultiplayerMapInfo(scenario, scnr);
                    break;

                case FirefightMapInfo firefightMapInfo:
                    firefightMapInfo.ConvertFirefightMapInfo(scenario, scnr);
                    break;
            }

            return scenario;
        }
    }
}
