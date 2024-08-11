using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.Commands.Common;

namespace TagTool.MtnDewIt.Commands
{
    class UpdateTagListCommand : Command
    {
        private GameCache Cache { get; }

        public static Dictionary<int, string> tagNameTable { get; set; }

        public enum TagListVersion : int
        {
            ElDewrito,
            ElDewritoLegacy,
            MS23,
        }

        public UpdateTagListCommand(GameCache cache): base
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

            // TODO: Figure out a proper folder structure for all these JSON files
            switch (tagListVersion)
            {
                case TagListVersion.ElDewrito:
                    jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\tag_names\ed_tag_name_table.json");
                    break;
                case TagListVersion.ElDewritoLegacy:
                    jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\tag_names\ed_legacy_tag_name_table.json");
                    break;
                case TagListVersion.MS23:
                    jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\tag_names\ms23_tag_name_table.json");
                    break;
            }

            tagNameTable = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonData);

            if (Cache is GameCacheHaloOnline)
            {
                var cache = Cache as GameCacheHaloOnline;

                foreach (var tag in cache.TagCache.NonNull())
                {
                    if (tagNameTable.TryGetValue(tag.Index, out string name))
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
                    if (tagNameTable.TryGetValue(tag.Index, out string name))
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