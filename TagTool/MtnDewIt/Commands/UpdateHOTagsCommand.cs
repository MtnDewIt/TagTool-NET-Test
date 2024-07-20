using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands
{
    class UpdateHOTagsCommand : Command
    {
        private GameCacheHaloOnline CacheContext { get; }

        public static Dictionary<int, string> tagNameTable { get; set; }

        public UpdateHOTagsCommand(GameCacheHaloOnline cacheContext): base
        (
            false,
            "UpdateHOTags",
            "Will attempt to correctly name all the tags within a Halo Online MS23 cache",
            "UpdateHOTags",
            "Will attempt to correctly name all the tags within a Halo Online MS23 cache"
        )
        {
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            // TODO: Create a custom JSON handler to handle loading, and maybe the creation of json files
            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\tag_names\ms23_tag_name_table.json");

            tagNameTable = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonData);

            foreach (var tag in CacheContext.TagCache.NonNull())
            {
                if (tagNameTable.TryGetValue(tag.Index, out string name))
                {
                    tag.Name = name;
                }
            }

            CacheContext.SaveTagNames();

            return true;
        }
    }
}