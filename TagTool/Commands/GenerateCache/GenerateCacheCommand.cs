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
        public enum GeneratedCacheType
        {
            Halo3,
            Halo3Mythic,
            Halo3ODST,
            ElDewrito,
            HaloOnline,
        }

        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public Stream CacheStream { get; set; }
        public static DirectoryInfo OutputDirectoryInfo { get; set; }
        public GeneratedCacheType CacheType { get; set; }

        public GenerateCacheCommand(GameCache cache) : base
        (
            true,
            "GenerateCache",
            "Generates a new cache for use with ElDewrito 0.7.1",
            "GenerateCache <Output Path> <Cache Type>",
            //"GenerateCache <JSON Path> <Output Path> <Scenario Path>",

            // TODO: Redo help text :/
            "It's similar to the MCC Tools, but don't try and use MCC loose tags" 
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args) 
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            OutputDirectoryInfo = new DirectoryInfo(args[0]);

            if (!OutputDirectoryInfo.Exists)
                return new TagToolError(CommandError.CustomError, "Output path does not exist, or could not be found");

            if (OutputDirectoryInfo.FullName == Cache.Directory.FullName)
                return new TagToolError(CommandError.CustomError, "Output path cannot be the same as the current working directory");

            if (Enum.TryParse(typeof(GeneratedCacheType), args[1], true, out object result))
                CacheType = (GeneratedCacheType)result;
            else
                return new TagToolError(CommandError.CustomError, $"Invalid Cache Type: '{args[1]}'");

            Program._stopWatch.Start();

            RebuildCache(OutputDirectoryInfo.FullName);
            RetargetCache(OutputDirectoryInfo.FullName);

            using (CacheStream = Cache.OpenCacheReadWrite()) 
            {
                UpdateTagData();
                UpdateMapData();
                UpdateBlfData();
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