using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;

namespace TagTool.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public Stream CacheStream { get; set; }
        public static DirectoryInfo SourceDirectoryInfo { get; set; }
        public static DirectoryInfo OutputDirectoryInfo { get; set; }

        public GenerateCacheCommand(GameCache cache) : base
        (
            true,
            "GenerateCache",
            "Generates a new cache for use with ElDewrito 0.7.1",
            "GenerateCache <Source Path> <Output Path> <Scenario Path>",

            // TODO: Redo help text :/
            "It's similar to the MCC Tools, but don't try and use MCC loose tags" 
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args) 
        {
            if (args.Count > 3)
                return new TagToolError(CommandError.ArgCount);

            SourceDirectoryInfo = new DirectoryInfo(args[0]);
            OutputDirectoryInfo = new DirectoryInfo(args[1]);

            if (!SourceDirectoryInfo.Exists)
                return new TagToolError(CommandError.CustomError, "Source data path does not exist, or could not be found");

            if (!OutputDirectoryInfo.Exists)
                return new TagToolError(CommandError.CustomError, "Output path does not exist, or could not be found");

            if (OutputDirectoryInfo.FullName == Cache.Directory.FullName)
                return new TagToolError(CommandError.CustomError, "Output path cannot be the same as the current working directory");

            Program._stopWatch.Start();

            RebuildCache(OutputDirectoryInfo.FullName);
            RetargetCache(OutputDirectoryInfo.FullName);

            using (CacheStream = Cache.OpenCacheReadWrite()) 
            {
                ParseJSONData(SourceDirectoryInfo.FullName, args[2]);
            }

            Program._stopWatch.Stop();

            var output = Program._stopWatch.ElapsedMilliseconds.FormatMilliseconds();
            var startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cache Generated Sucessfully. Time Taken: " + output);
            Console.ForegroundColor = startColor;

            return true;
        }
    }
}