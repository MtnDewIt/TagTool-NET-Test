using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.JSON;

namespace TagTool.Commands.Tags
{
    class UpdateTagListCommand : Command
    {
        private GameCache Cache { get; }

        public static Dictionary<int, string> TagNameTable { get; set; }

        public UpdateTagListCommand(GameCache cache) : base
        (
            false,
            "UpdateTagList",
            "Updates tag name table based on the specified tag list",
            "UpdateTagList <Path to JSON Tag List>",
            "Updates tag name table based on the specified tag list"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            string jsonData = "";

            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            if (!File.Exists(args[0]))
                return new TagToolError(CommandError.FileNotFound);

            jsonData = File.ReadAllText(args[0]);

            TagNameTable = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonData);

            if (Cache is GameCacheHaloOnline)
            {
                var cache = Cache as GameCacheHaloOnline;

                foreach (var tag in cache.TagCache.NonNull())
                {
                    if (TagNameTable.TryGetValue(tag.Index, out string name))
                    {
                        tag.Name = name;
                    }
                }

                cache.SaveTagNames();
            }

            if (Cache is GameCacheModPackage)
            {
                var cache = Cache as GameCacheModPackage;

                foreach (var tag in cache.TagCache.NonNull())
                {
                    if (TagNameTable.TryGetValue(tag.Index, out string name))
                    {
                        tag.Name = name;
                    }
                }

                cache.SaveTagNames();
            }

            return true;
        }
    }
}