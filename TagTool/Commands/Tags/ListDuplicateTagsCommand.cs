using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;

namespace TagTool.Commands.Tags
{
    class ListDuplicateTagsCommand : Command
    {
        public GameCacheHaloOnlineBase Cache { get; }

        public ListDuplicateTagsCommand(GameCacheHaloOnlineBase cache)
            : base(true,

                  "ListDuplicateTags",
                  "Prints out a list of tags with duplicate names.",

                  "ListDuplicateTags",

                  "Prints out a list of tags with duplicate names.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            var tags = Cache.TagCacheGenHO.NonNull().GroupBy(x => $"{x.Name}.{x.Group}").Where(x => x.Count() > 1).ToList();
            foreach (var duplicates in tags)
            {
                foreach (var duplicate in duplicates)
                {
                    Console.WriteLine($"{duplicate.Index:X04} {duplicate}");
                }
            }
            return true;
        }
    }
}
