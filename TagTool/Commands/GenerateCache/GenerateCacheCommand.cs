using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using Newtonsoft.Json;
using TagTool.Commands.Porting;
using TagTool.JSON;

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
        public CommandContextStack ContextStack { get; set; }
        public Stream CacheStream { get; set; }
        public static DirectoryInfo OutputDirectoryInfo { get; set; }
        public GeneratedCacheType CacheType { get; set; }

        public GenerateCacheCommand(GameCache cache, CommandContextStack contextStack) : base
        (
            true,
            "GenerateCache",
            "Generates a new cache for use with ElDewrito 0.7",
            "GenerateCache",

            // TODO: Redo help text :/
            "It's similar to the MCC Tools, but don't try and use MCC loose tags" 
        )
        {
            Cache = cache;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args) 
        {
            // Once this eventually gets overhauled, we need to decide on what input data the command is going to require.
            // IDEAS:
            // - JSON Tag Object Path - I don't know if this should be in a config file, just be a static path or something that is available directly to the user
            // - Cache Output Path - I don't know if this should be in a config file, just be a static path or something that is available directly to the user
            // - Target Scenario - Obviously needs to be an input

            // TODO: Remove need for Console.ReadLine and just parse args using standard command input system
            GetCacheFiles();

            Program._stopWatch.Start();

            RebuildCache(OutputDirectoryInfo.FullName);
            RetargetCache(OutputDirectoryInfo.FullName);

            using (CacheStream = Cache.OpenCacheReadWrite()) 
            {
                UpdateTagData();
                UpdateMapData();
                UpdateBlfData();
            }

            ContextStack.Pop();

            Program._stopWatch.Stop();

            var output = Program._stopWatch.ElapsedMilliseconds.FormatMilliseconds();
            var startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cache Generated Sucessfully. Time Taken: " + output);
            Console.ForegroundColor = startColor;

            return true;
        }

        public void GetCacheFiles()
        {
            // This will become redundant once recursion is added to the JSON parser, as the user can just specify manually which scenario to include
            CacheType = GetCacheType();

            // Need to figure out how to handle this correctly (either have the user determine the output path, or have it be static and relative to the assembly location)
            OutputDirectoryInfo = GetOutputDirectory(OutputDirectoryInfo);
        }

        public GeneratedCacheType GetCacheType() 
        {
            Console.WriteLine("\nEnter the cache type: ");
            var inputType = Console.ReadLine().Replace("\"", "");

            if (Enum.TryParse(typeof(GeneratedCacheType), inputType, true, out object result))
            {
                return (GeneratedCacheType)result;
            }
            else 
            {
                new TagToolError(CommandError.CustomError, $"Invalid Cache Type: '{inputType}'");
                throw new ArgumentException();
            }
        }

        public DirectoryInfo GetOutputDirectory(DirectoryInfo directoryInfo)
        {
            Console.WriteLine("\nEnter the ouput directory for the generated cache: ");
            var inputDirectory = Console.ReadLine().Replace("\"", "");
            directoryInfo = new DirectoryInfo(inputDirectory);

            if (!directoryInfo.Exists)
            {
                new TagToolWarning("This directory does not exist, or could not be found. Creating a new one...");
                directoryInfo.Create();
            }

            if (directoryInfo.FullName == Cache.Directory.FullName)
            {
                new TagToolError(CommandError.CustomError, "Output directory cannot be the same as working directory");
                throw new ArgumentException();
            }

            return directoryInfo;
        }
    }
}