using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.MCC.Headers;

namespace TagTool.Commands.Tags
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, CommandContextStack contextStack) : base
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
            string output = args[0];

            Dictionary<int, string> tagTable = [];

            foreach (var tag in Cache.TagCache.TagTable) 
            {
                tagTable.Add((int)tag.ID, $"{tag.Name}.{tag.Group.Tag}");
            }

            string mapName = Cache.DisplayName.Replace(".map", string.Empty);
            FileInfo fileInfo = new FileInfo($"{output}\\{mapName}_mappings.json");

            if (!Directory.Exists(fileInfo.DirectoryName)) 
            {
                Directory.CreateDirectory(fileInfo.DirectoryName);
            }

            File.WriteAllText(fileInfo.FullName, JsonConvert.SerializeObject(tagTable, Formatting.Indented));

            return true;
        }
    }
}