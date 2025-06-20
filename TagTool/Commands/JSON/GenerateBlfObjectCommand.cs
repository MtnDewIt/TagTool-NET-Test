using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.IO;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TagTool.Commands.Common;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TagTool.Commands.JSON
{
    public class GenerateBlfObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;
        private string PathPrefix = null;

        private int FileCount = 0;
        private Stopwatch StopWatch = new Stopwatch();
        private List<string> ErrorLog = new List<string>();

        private static readonly string[] ValidExtensions =
        {
            ".assault",
            ".ctf",
            ".jugg",
            ".koth",
            ".oddball",
            ".slayer",
            ".terries",
            ".vip",
            ".zombiez",
            ".map",
            ".mapinfo",
            ".campaign",
            ".blf",
            ".bin",
            ".mvar",
            ".film",
            ".clip",
            ".shot"
        };

        public GenerateBlfObjectCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext) : base
        (
            false,
            "GenerateBlfObject",
            "Generates a JSON blf object file based on the specified blf file",

            "GenerateBlfObject <File_Path> [PathPrefix]",
            "Generates a JSON blf object file based on the specified blf file"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            FileCount = 0;
            StopWatch.Reset();
            ErrorLog.Clear();

            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            PathPrefix = args.Count == 2 ? args[1] : null;

            ProcessDirectoryAsync(args[0]).GetAwaiter().GetResult();

            Console.WriteLine($"{FileCount - ErrorLog.Count}/{FileCount} Variants Converted Successfully in {StopWatch.ElapsedMilliseconds.FormatMilliseconds()} with {ErrorLog.Count} {(ErrorLog.Count == 1 ? "error" : "errors")}\n");

            if (ErrorLog.Count > 0)
            {
                ParseErrorLog();
            }

            PathPrefix = null;

            return true;
        }

        public async Task ProcessDirectoryAsync(string inputPath)
        {
            var files = new List<string>();

            if (File.Exists(inputPath))
                files.Add(inputPath);
            else if (Directory.Exists(inputPath))
                files = Directory.EnumerateFiles(inputPath, "*.*", SearchOption.AllDirectories).Where(file => ValidExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();
            else
                new TagToolError(CommandError.DirectoryNotFound);

            FileCount = files.Count;

            StopWatch.Start();

            var tasks = files.Select(ConvertFileAsync);
            await Task.WhenAll(tasks);

            StopWatch.Start();
        }

        private async Task ConvertFileAsync(string filePath)
        {
            try 
            {
                var file = new FileInfo(filePath);

                var fileName = Path.GetFileNameWithoutExtension(file.Name);
                var fileExtension = file.Extension.TrimStart('.');

                var exportPath = PathPrefix != null ? Path.Combine(PathPrefix, $@"maps\info") : $@"maps\info";

                using (var stream = file.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    var blfData = new Blf(Cache.Version, Cache.Platform);
                    blfData.Read(reader);

                    var blfObject = new BlfObject()
                    {
                        FileName = fileName,
                        FileType = fileExtension,
                        Blf = blfData,
                    };

                    if (blfData.ContentHeader != null)
                    {
                        switch (blfData.Version, blfData.CachePlatform) 
                        {
                            case (CacheVersion.HaloReach, CachePlatform.Original):
                            case (CacheVersion.HaloReach, CachePlatform.MCC):
                                fileName = blfData.ContentHeader.MetadataReach.Name.TrimEnd();
                                break;
                            default:
                                fileName = blfData.ContentHeader.Metadata.Name.TrimEnd();
                                break;
                        }
                    }

                    var handler = new BlfObjectHandler(blfData.Version, blfData.CachePlatform);

                    var jsonData = handler.Serialize(blfObject);

                    var fileInfo = new FileInfo(Path.Combine(exportPath, $"{fileName}.json"));

                    if (!fileInfo.Directory.Exists)
                    {
                        fileInfo.Directory.Create();
                    }

                    File.WriteAllText(fileInfo.FullName, jsonData);
                }
            }
            catch (Exception e)
            {
                ErrorLog.Add($"Error converting \"{filePath}\" : {e.Message}");
            }
        }

        public void ParseErrorLog()
        {
            var time = DateTime.Now;
            var shortDateTime = $@"{time.ToShortDateString()}-{time.ToShortTimeString()}";

            var fileName = Regex.Replace($"hott_{shortDateTime}_blf_errors.log", @"[<>:""/\|?*]", "_");
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