using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Commands.Common;
using System.IO;
using System;
using TagTool.Extensions;

namespace TagTool.Commands.Modding
{
    public class ExtractModFilesCommand : Command
    {
        public GameCacheModPackage Cache { get; }

        public ExtractModFilesCommand(GameCacheModPackage cache) :
            base(true,
                "ExtractModFiles",
                "Extracts files from mod package to the specified path.",

                "ExtractModFiles <Destination Path> [Filter]",

                "Extracts files from mod package to the specified path.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            var directory = new DirectoryInfo(args[0]);

            if (!directory.Exists)
                return new TagToolError(CommandError.DirectoryNotFound);

            var filter = args.Count > 1 ? args[1] : null;

            var modFiles = Cache.BaseModPackage.Files;

            if (modFiles != null && modFiles.Count > 0) 
            {
                foreach (var modfile in modFiles)
                {
                    Console.WriteLine($"Extracting \"{modfile.Key}\"");

                    var filePath = Path.Combine(directory.FullName, modfile.Key);

                    if (filter != null)
                    {
                        if (!filePath.Contains(filter))
                            continue;
                    }

                    var directoryName = Path.GetDirectoryName(modfile.Key.ToString());

                    if (!string.IsNullOrEmpty(directoryName))
                        directory.CreateSubdirectory(directoryName);

                    var modFile = new FileInfo(filePath);

                    if (modFile.Exists)
                    {
                        Console.WriteLine("Overwriting Existing file: " + filePath);
                        modFile.Delete();
                    }

                    using (var modFileStream = modFile.Create())
                    {
                        modfile.Value.Position = 0;
                        modfile.Value.CopyTo(modFileStream);
                    }
                }

                Console.WriteLine("Done.");
            }
            else
                Console.WriteLine("Mod package does not contain any mod files.");

            return true;
        }
    }
}
