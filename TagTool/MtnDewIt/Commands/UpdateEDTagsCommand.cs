using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands
{
    class UpdateEDTagsCommand : Command
    {
        private GameCache Cache { get; }

        public static Dictionary<int, string> tagNameTable { get; set; }

        public UpdateEDTagsCommand(GameCache cache) : base
        (
            false,
            "UpdateEDTags",
            "Will attempt to correctly name all the tags within an ElDewrito 0.7.1 cache",
            "UpdateEDTags",
            "Will attempt to correctly name all the tags within an ElDewrito 0.7.1 cache"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            // TODO: Create a custom JSON handler to handle loading, and maybe the creation of json files
            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\tag_names\ed_tag_name_table.json");
            
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