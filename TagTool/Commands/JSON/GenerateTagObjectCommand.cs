using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using System.Threading.Tasks;
using TagTool.Commands.Common;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TagTool.Commands.JSON
{
    public class GenerateTagObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private string ExportPath = $@"tags";
        private string Suffix = null;

        private int TagCount = 0;
        private Stopwatch StopWatch = new Stopwatch();
        private List<string> ErrorLog = new List<string>();

        public GenerateTagObjectCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            false,
            "GenerateTagObject",
            "Generates a JSON tag object file based on the specified tag",

            "GenerateTagObject <Tag_Name> [Suffix]",
            "Generates a JSON tag object file based on the specified tag. Flags within\n" +
            "the generated JSON data may change depending on the tag's definition and type"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            Suffix = args.Count > 1 ? args[1] : null;

            ProcessInputAsync(args[0]).GetAwaiter().GetResult();

            Console.WriteLine($"{TagCount - ErrorLog.Count}/{TagCount} Tags Converted Successfully in {StopWatch.ElapsedMilliseconds.FormatMilliseconds()} with {ErrorLog.Count} errors\n");

            if (ErrorLog.Count > 0)
            {
                ParseErrorLog();
            }

            return true;
        }

        public async Task ProcessInputAsync(string input) 
        {
            var tagTable = new List<CachedTag>();

            if (Cache.TagCache.TryGetCachedTag(input, out var tag))
                tagTable.Add(tag);
            else if (input.Equals("all", StringComparison.OrdinalIgnoreCase))
                tagTable = Cache.TagCache.NonNull().ToList();
            else 
                new TagToolError(CommandError.TagInvalid);

            TagCount = tagTable.Count;

            using (var cacheStream = Cache.OpenCacheRead()) 
            {
                StopWatch.Start();

                var tasks = tagTable.Select(tag => ConvertTagAsync(tag, cacheStream));
                await Task.WhenAll(tasks);

                StopWatch.Stop();
            }
        }

        private async Task ConvertTagAsync(CachedTag tag, Stream cacheStream) 
        {
            try 
            {
                var definition = (TagStructure)Cache.Deserialize(cacheStream, tag);
                var definitionName = TagStructure.GetTagStructureInfo(Cache.TagCache.TagDefinitions.GetTagDefinitionType(tag.Group), Cache.Version, Cache.Platform).Structure.Name;

                var fileName = Suffix != null ? $"{tag.Name}_{Suffix}" : tag.Name;

                var tagObject = new TagObject()
                {
                    TagName = tag.Name,
                    TagType = definitionName,
                    TagVersion = Cache.Version,
                    TagData = definition,
                };

                // When deserialising the data for these types we want to ensure that the tag exists in the cache no matter what
                if (definition.GetType() == typeof(RenderMethodDefinition))
                {
                    tagObject.Generate = true;
                }

                var handler = new TagObjectHandler(Cache, CacheContext, cacheStream);

                var jsonData = handler.Serialize(tagObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{fileName}.{definitionName}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{fileName}.{definitionName}.json"), jsonData);
            }
            catch (Exception e)
            {
                ErrorLog.Add($"Error converting \"{tag.Name}.{tag.Group}\" : {e.Message}");
            }
        }

        public void ParseErrorLog()
        {
            var time = DateTime.Now;
            var shortDateTime = $@"{time.ToShortDateString()}-{time.ToShortTimeString()}";

            var fileName = Regex.Replace($"hott_{shortDateTime}_tag_errors.log", @"[*\\ /:]", "_");
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