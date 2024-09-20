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
            var jsonData = File.ReadAllText(args[0]);

            var multiplayerMapInfo = JsonConvert.DeserializeObject<MultiplayerMapInfo>(jsonData);
            //var campaignMapInfo = JsonConvert.DeserializeObject<CampaignMapInfo>(jsonData);
            //var firefightMapInfo = JsonConvert.DeserializeObject<FirefightMapInfo>(jsonData);
            //var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);
            //var campaignInfo = JsonConvert.DeserializeObject<CampaignInfo>(jsonData);

            return true;
        }
    }
}
