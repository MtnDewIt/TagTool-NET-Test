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
            var parentFiles = Directory.GetFiles(args[0], $@"*.json");

            foreach (var file in parentFiles) 
            {
                var jsonData = File.ReadAllText(file);

                if (file.EndsWith($@"CampaignInfo.json"))
                {
                    var campaignInfo = JsonConvert.DeserializeObject<CampaignInfo>(jsonData);

                    if (campaignInfo.CampaignMaps != null) 
                    {
                        foreach (var map in campaignInfo.CampaignMaps)
                        {
                            var path = Path.Combine(args[0], map);
                            var mapInfo = File.ReadAllText(path);

                            var campaignMapInfo = JsonConvert.DeserializeObject<CampaignMapInfo>(mapInfo);
                        }
                    }
                }

                if (file.EndsWith($@"ModInfo.json"))
                {
                    var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);

                    if (modInfo.GameModContents.MultiplayerMaps != null) 
                    {
                        foreach (var map in modInfo.GameModContents.MultiplayerMaps)
                        {
                            var path = Path.Combine(args[0], map);
                            var mapInfo = File.ReadAllText(path);

                            var multiplayerMapInfo = JsonConvert.DeserializeObject<MultiplayerMapInfo>(mapInfo);
                        }
                    }

                    if (modInfo.GameModContents.FirefightMaps != null) 
                    {
                        foreach (var map in modInfo.GameModContents.FirefightMaps)
                        {
                            var path = Path.Combine(args[0], map);
                            var mapInfo = File.ReadAllText(path);

                            var firefightMapInfo = JsonConvert.DeserializeObject<FirefightMapInfo>(mapInfo);
                        }
                    }
                }
            }

            return true;
        }
    }
}
