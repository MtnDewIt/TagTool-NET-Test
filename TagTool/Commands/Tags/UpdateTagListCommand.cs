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

        public enum TagListVersion : int
        {
            ElDewrito071,
            ElDewrito061,
            ElDewrito051,
            MS23,
        }

        public UpdateTagListCommand(GameCache cache) : base
        (
            false,
            "UpdateTagList",
            "Updates tag name table based on the specified tag list",
            "UpdateTagList <TagListVersion>",
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

            if (!Enum.TryParse(args[0], true, out TagListVersion tagListVersion))
                return new TagToolError(CommandError.ArgInvalid);

            switch (tagListVersion)
            {
                case TagListVersion.ElDewrito071:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONTagTablePath}\071_tags.json");
                    break;
                case TagListVersion.ElDewrito061:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONTagTablePath}\061_tags.json");
                    break;
                case TagListVersion.ElDewrito051:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONTagTablePath}\051_tags.json");
                    break;
                case TagListVersion.MS23:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONTagTablePath}\ms23_tags.json");
                    break;
            }

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