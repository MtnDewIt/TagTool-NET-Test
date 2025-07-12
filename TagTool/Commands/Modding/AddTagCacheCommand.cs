using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.ModPackages;
using TagTool.Commands.Common;

namespace TagTool.Commands.Modding
{
    public class AddTagCacheCommand : Command
    {
        private GameCacheModPackage Cache;

        public AddTagCacheCommand(GameCacheModPackage modCache) :
            base(true,

                "AddTagCache",
                "Add the specified number of tag caches to the mod package.",

                "AddTagCache [Number of tag caches]",

                "Add the specified number of tag caches to the mod package.")
        {
            Cache = modCache;
        }

        public override object Execute(List<string> args)
        {
            int tagCacheCount = 1;

            if (args.Count > 0 && !int.TryParse(args[0], System.Globalization.NumberStyles.Integer, null, out tagCacheCount))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\"");
                
            // initialze mod package with current HO cache
            Console.WriteLine($"Building initial tag cache from reference...");

            // will be reused by all caches
            ModPackageCacheUtils.BuildInitialTagCache(
                Cache.BaseCacheReference, 
                out Dictionary<int, string> referenceTagNames, 
                out Stream referenceStream);

            var currentTagCacheCount = Cache.BaseModPackage.GetTagCacheCount();

            for (int i = currentTagCacheCount; i < tagCacheCount + currentTagCacheCount; i++)
            {
                Console.WriteLine($"Enter the name of tag cache {i + 1} (32 chars max):");
                string name = Console.ReadLine().Trim();
                name = name.Length <= 32 ? name : name.Substring(0, 32);

                var newTagCacheStream = new MemoryStream();
                referenceStream.Position = 0;
                referenceStream.CopyTo(newTagCacheStream);

                Cache.BaseModPackage.AddTagCache(name, referenceTagNames.ToDictionary(), newTagCacheStream);
            }

            Console.WriteLine("Done!");
            return true;
        }
    }
}