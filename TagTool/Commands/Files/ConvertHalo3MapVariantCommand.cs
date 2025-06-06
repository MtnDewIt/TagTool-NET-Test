﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Commands.Files
{
    public class ConvertHalo3MapVariantCommand : Command
    {
        private readonly GameCacheHaloOnlineBase Cache;

        private string OutputPath = "";

        private Stopwatch StopWatch = new Stopwatch();
        private int FileCount = 0;
        private List<string> ErrorLog = new List<string>();
        private List<ulong> UniqueIdTable = new List<ulong>();

        private static readonly string[] ValidExtensions =
        {
            ".assault",
            ".bin",
            ".clip",
            ".ctf",
            ".film",
            ".jugg",
            ".koth",
            ".map",
            ".oddball",
            ".sandbox",
            ".shot",
            ".slayer",
            ".terries",
            ".vip",
            ".zombiez",
        };

        private static readonly Dictionary<int, string> MapIdToFilename = new Dictionary<int, string>()
        {
            [030] = "zanzibar",
            [300] = "construct",
            [310] = "deadlock",
            [320] = "guardian",
            [330] = "isolation",
            [340] = "riverworld",
            [350] = "salvation",
            [360] = "snowbound",
            [380] = "chill",
            [390] = "cyberdyne",
            [400] = "shrine",
            [410] = "bunkerworld",
            [440] = "docks",
            [470] = "sidewinder",
            [480] = "warehouse",
            [490] = "descent",
            [500] = "spacecamp",
            [520] = "lockout",
            [580] = "armory",
            [590] = "ghosttown",
            [600] = "chillout",
            [720] = "midship",
            [730] = "sandbox",
            [740] = "fortress",
        };

        private static readonly Dictionary<ContentItemType, string> ContentTypeToFileExtension = new Dictionary<ContentItemType, string>()
        {
            [ContentItemType.None] = ".bin",
            [ContentItemType.CtfVariant] = ".ctf",
            [ContentItemType.SlayerVariant] = ".slayer",
            [ContentItemType.OddballVariant] = ".oddball",
            [ContentItemType.KingOfTheHillVariant] = ".koth",
            [ContentItemType.JuggernautVariant] = ".jugg",
            [ContentItemType.TerritoriesVariant] = ".terries",
            [ContentItemType.AssaultVariant] = ".assault",
            [ContentItemType.InfectionVariant] = ".zombiez",
            [ContentItemType.VipVariant] = ".vip",
            [ContentItemType.SandboxMap] = ".map",
        };

        public ConvertHalo3MapVariantCommand(GameCacheHaloOnlineBase cache)
            : base(true,

                  "ConvertHalo3MapVariant",
                  "Converts all halo 3 map variants in the specified path",

                  "ConvertHalo3MapVariant <maps directory> <input directory> [output directory]",
                  "Converts all reach map variants in the specified path")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 3)
                return new TagToolError(CommandError.ArgCount);

            var mapsDirectory = new DirectoryInfo(args[0]);
            if (!mapsDirectory.Exists)
                return new TagToolError(CommandError.DirectoryNotFound, "Maps directory not found");

            OutputPath = args.Count > 2 ? args[2] : "";

            FileCount = 0;
            StopWatch.Reset();
            ErrorLog.Clear();
            UniqueIdTable.Clear();

            ProcessDirectoryAsync(args[1], mapsDirectory).GetAwaiter().GetResult();

            Console.WriteLine($"{FileCount - ErrorLog.Count}/{FileCount} Map Variants Converted Successfully in {StopWatch.ElapsedMilliseconds.FormatMilliseconds()} with {ErrorLog.Count} {(ErrorLog.Count == 1 ? "error" : "errors")}\n");

            if (ErrorLog.Count > 0)
            {
                ParseErrorLog();
            }

            return true;
        }

        private async Task ProcessDirectoryAsync(string inputPath, DirectoryInfo mapsDirectory)
        {
            var files = new List<string>();

            if (File.Exists(inputPath))
                files.Add(inputPath);
            else if (Directory.Exists(inputPath))
                files = Directory.EnumerateFiles(inputPath, "*.*", SearchOption.AllDirectories).Where(file => ValidExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();
            else
                new TagToolError(CommandError.DirectoryNotFound, "Input directory not found");

            FileCount = files.Count;

            StopWatch.Start();

            var tasks = files.Select(filePath => ConvertFileAsync(filePath, mapsDirectory));
            await Task.WhenAll(tasks);

            StopWatch.Stop();
        }

        private async Task ConvertFileAsync(string filePath, DirectoryInfo mapsDirectory)
        {
            var input = new FileInfo(filePath);
            var blf = new Blf(CacheVersion.Halo3Retail, CachePlatform.Original);

            string variantName = "";
            ulong uniqueId = 0;
            ContentItemType contentType = ContentItemType.None;

            try
            {
                using (var stream = input.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var reader = new EndianReader(stream);

                    blf.Read(reader);

                    if (blf.MapVariant != null) 
                    {
                        var sourceCache = GetMapCache(mapsDirectory, blf.MapVariant.MapVariant.MapId);

                        blf.MapVariantTagNames = new BlfMapVariantTagNames()
                        {
                            Signature = new Tag("tagn"),
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariantTagNames), blf.Version, CachePlatform.Original),
                            MajorVersion = 1,
                            MinorVersion = 0,
                            Names = Enumerable.Range(0, 256).Select(x => new TagName()).ToArray(),
                        };
                        blf.ContentFlags |= BlfFileContentFlags.MapVariantTagNames;

                        // The main issue is the scenario object placements. If objects still aren't appearinf on the map, try decreasing the scenario object count

                        for (int i = 0; i < blf.MapVariant.MapVariant.Quotas.Length; i++)
                        {
                            var quota = blf.MapVariant.MapVariant.Quotas[i];

                            var quotaObject = sourceCache.TagCache.GetTag((uint)quota.ObjectDefinitionIndex);

                            if (quotaObject != null)
                            {
                                blf.MapVariantTagNames.Names[i].Name = $"{quotaObject.Name}.{quotaObject.Group.Tag}";
                                quota.ObjectDefinitionIndex = 0;
                                quota.MaximumCount = 255;
                                quota.MaxAllowed = 255;
                            }
                            else 
                            {
                                quota.ObjectDefinitionIndex = 0;
                                quota.MaxAllowed = 255;
                                quota.Cost = -1;
                            }
                        }

                        var newObjectIndexes = new short[16];

                        for (int i = 0; i < blf.MapVariant.MapVariant.ObjectTypeStartIndex.Length; i++)
                        {
                            newObjectIndexes[i] = blf.MapVariant.MapVariant.ObjectTypeStartIndex[i];
                        }

                        blf.MapVariant.MapVariant.ObjectTypeStartIndex = newObjectIndexes;
                    }

                    blf.Version = CacheVersion.HaloOnlineED;
                    blf.CachePlatform = CachePlatform.Original;
                    blf.Format = EndianFormat.LittleEndian;

                    uniqueId = blf.ContentHeader?.Metadata?.UniqueId ?? 0;
                    variantName = blf.ContentHeader?.Metadata?.Name ?? "";
                    contentType = blf.ContentHeader?.Metadata?.ContentType ?? ContentItemType.None;
                }

                var output = GetOutputPath(variantName, contentType, uniqueId);

                Directory.CreateDirectory(Path.GetDirectoryName(output));

                using (var stream = new FileInfo(output).Create())
                {
                    var writer = new EndianWriter(stream);
                    blf.Write(writer);
                }

                if (uniqueId != 0)
                {
                    UniqueIdTable.Add(uniqueId);
                }
            }
            catch (Exception e)
            {
                ErrorLog.Add($"Error converting \"{filePath}\" : {e.Message}");
            }
        }

        private GameCache GetMapCache(DirectoryInfo mapsDirectory, int mapId)
        {
            var mapFile = new FileInfo(Path.Combine(mapsDirectory.FullName, $"{MapIdToFilename[mapId]}.map"));
            if (!mapFile.Exists)
            {
                throw new Exception($"'{MapIdToFilename[mapId]}.map' could not be found.");
            }
            return GameCache.Open(mapFile);
        }

        private string GetOutputPath(string variantName, ContentItemType contentType, ulong uniqueId)
        {
            var filteredName = Regex.Replace($"{variantName.TrimStart().TrimEnd().TrimEnd('.')}", @"[<>:""/\|?*]", "_");

            string outputPath = contentType == ContentItemType.SandboxMap ? Path.Combine(OutputPath, $@"map_variants", filteredName, $@"sandbox{ContentTypeToFileExtension[contentType]}") : Path.Combine(OutputPath, $@"game_variants", filteredName, $@"variant{ContentTypeToFileExtension[contentType]}");

            if (Path.Exists(outputPath) && UniqueIdTable.Contains(uniqueId))
            {
                throw new Exception("Duplicate Variant");
            }
            else
            {
                return outputPath;
            }
        }

        public void ParseErrorLog()
        {
            var time = DateTime.Now;
            var shortDateTime = $@"{time.ToShortDateString()}-{time.ToShortTimeString()}";

            var fileName = Regex.Replace($"hott_{shortDateTime}_variant_errors.log", @"[<>:""/\|?*]", "_");
            var filePath = "logs";
            var fullPath = Path.Combine(Program.TagToolDirectory, filePath, fileName);

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            using (StreamWriter writer = new StreamWriter(File.Create(fullPath)))
            {
                foreach (var error in ErrorLog)
                {
                    writer.WriteLine(error);
                }
            }

            Console.WriteLine($"Check \"{fullPath}\" for details on errors");
        }
    }
}
