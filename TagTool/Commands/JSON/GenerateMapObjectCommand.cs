using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.IO;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using System.Threading.Tasks;
using System.Linq;
using TagTool.Commands.Common;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TagTool.Common;

namespace TagTool.Commands.JSON
{
    public class GenerateMapObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private string ExportPath = $@"maps";
        private string Suffix = null;

        private int MapCount = 0;
        private Stopwatch StopWatch = new Stopwatch();
        private List<string> ErrorLog = new List<string>();

        public GenerateMapObjectCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            false,
            "GenerateMapObject",
            "Generates a JSON map object file based on the specified map file",

            "GenerateMapObject <Map_Path> [Suffix]",
            "Generates a JSON map object file based on the specified map file\n\n" + 

            "Optionally, instead of specifying a map file to convert you can\n" + 
            "use \"all\", which will convert all map files associated with\n" +
            "the current cache context"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            Suffix = args.Count > 1 ? args[1] : null;

            ProcessDirectoryAsync(args[0]).GetAwaiter().GetResult();

            Console.WriteLine($"{MapCount - ErrorLog.Count}/{MapCount} Variants Converted Successfully in {StopWatch.ElapsedMilliseconds.FormatMilliseconds()} with {ErrorLog.Count} {(ErrorLog.Count == 1 ? "error" : "errors")}\n");

            if (ErrorLog.Count > 0)
            {
                ParseErrorLog();
            }

            return true;
        }

        public async Task ProcessDirectoryAsync(string inputPath)
        {
            var files = new List<string>();

            if (File.Exists(inputPath))
                files.Add(inputPath);
            else if (inputPath.Equals("all", StringComparison.OrdinalIgnoreCase))
                files = Directory.EnumerateFiles(Cache.Directory.FullName, "*.map").ToList();
            else
                new TagToolError(CommandError.FileNotFound);

            MapCount = files.Count;

            StopWatch.Start();

            var tasks = files.Select(ConvertMapAsync);
            await Task.WhenAll(tasks);

            StopWatch.Start();
        }

        private async Task ConvertMapAsync(string filePath) 
        {
            try
            {
                var file = new FileInfo(filePath);

                var mapData = new MapFile();

                var mapName = Path.GetFileNameWithoutExtension(file.Name);

                var fileName = Suffix != null ? $"{mapName}_{Suffix}" : mapName;

                using (var stream = file.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    mapData.Read(reader);

                    var headerData = mapData.Header as CacheFileHeaderGenHaloOnline;

                    headerData.ScenarioTagIndex = 0;

                    var mapObject = new MapObject()
                    {
                        MapName = mapName,
                        MapVersion = mapData.Version,
                        Header = headerData,
                        MapFileBlf = mapData.MapFileBlf,
                    };

                    var handler = new MapObjectHandler(Cache, CacheContext);

                    var jsonData = handler.Serialize(mapObject);

                    var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{fileName}.json"));

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

            var fileName = Regex.Replace($"hott_{shortDateTime}_map_errors.log", @"[*\\ /:]", "_");
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