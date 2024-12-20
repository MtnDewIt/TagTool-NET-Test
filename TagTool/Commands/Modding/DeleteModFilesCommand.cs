using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Commands.Common;
using System.IO;
using System;
using TagTool.Extensions;

namespace TagTool.Commands.Modding
{
    public class DeleteModFilesCommand : Command
    {
        public GameCacheModPackage Cache { get; }

        public DeleteModFilesCommand(GameCacheModPackage cache) :
            base(true,
                "DeleteModFiles",
                "Deletes all the Mod files in the package",

                "DeleteModFiles [Filter]",

                "Deletes all the Mod files in the package")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            var filter = args.Count > 0 ? args[0] : null;

            var filteredList = Cache.BaseModPackage.Files;

            if (filteredList != null && filteredList.Count > 0)
            {
                if (filter != null)
                {
                    filteredList = new Dictionary<string, Stream>();

                    foreach (var modfile in Cache.BaseModPackage.Files)
                    {
                        if (modfile.Key.Contains(filter))
                            filteredList.Add(modfile.Key, modfile.Value);
                    }
                }

                foreach (var modfile in filteredList)
                {
                    Console.WriteLine($"Deleting \"{modfile.Key}\"");
                    Cache.BaseModPackage.Files.Remove(modfile.Key);
                }

                Console.WriteLine("Done.");
            }
            else
                Console.WriteLine("Mod package does not contain any mod files.");

            return true;
        }
    }
}
