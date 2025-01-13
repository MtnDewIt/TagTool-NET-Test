using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using TagTool.BlamFile.GameVariants;
using System.Text.RegularExpressions;
using TagTool.JSON;

namespace TagTool.Commands.Files
{
    class ConvertVariantCommand : Command
    {
        private GameCache Cache;
        private string OutputPath = "";
        private Dictionary<int, string> TagMap;

        private Stopwatch StopWatch = new Stopwatch();
        private int FileCount = 0;
        private List<string> ErrorLog = new List<string>();
        private List<ulong> UniqueIdTable = new List<ulong>();

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
            ".map"
        };

        public ConvertVariantCommand(GameCache cache) : base
        (
            true,
            "ConvertVariant",
            "Converts all ElDewrito 0.6 variants in the specified path",
            
            "ConvertVariant <input directory> [output directory]",
            "Converts all ElDewrito 0.6 variants in the specified path"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            FileCount = 0;
            StopWatch.Reset();
            ErrorLog.Clear();
            UniqueIdTable.Clear();

            if (Cache.Version != CacheVersion.HaloOnlineED) 
            {
                return new TagToolError(CommandError.CacheUnsupported, $"Unsupported Cache Version: {Cache.Version}");
            }

            OutputPath = args.Count > 1 ? args[1] : "";
            ProcessDirectoryAsync(args[0]).GetAwaiter().GetResult();

            Console.WriteLine($"{FileCount - ErrorLog.Count}/{FileCount} Variants Converted Successfully in {StopWatch.ElapsedMilliseconds.FormatMilliseconds()} with {ErrorLog.Count} {(ErrorLog.Count == 1 ? "error" : "errors")}\n");

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
            else if (Directory.Exists(inputPath))
                files = Directory.EnumerateFiles(inputPath, "*.*", SearchOption.AllDirectories).Where(file => ValidExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();
            else
                new TagToolError(CommandError.DirectoryNotFound);

            FileCount = files.Count;

            StopWatch.Start();

            var tasks = files.Select(ConvertFileAsync);
            await Task.WhenAll(tasks);

            StopWatch.Stop();
        }

        private async Task ConvertFileAsync(string filePath)
        {
            var input = new FileInfo(filePath);
            var blf = new Blf(Cache.Version, Cache.Platform);

            var variantName = "";

            try
            {
                using (var stream = input.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    FixBlfEndianness(stream, blf);
                    
                    if (blf.MapVariantTagNames == null && blf.MapVariant != null)
                    {
                        Convert06Blf(blf);
                    }

                    if (blf.EndOfFile == null)
                    {
                        blf.EndOfFile = new BlfChunkEndOfFile()
                        {
                            Signature = new Tag("_eof"),
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), blf.Version, Cache.Platform),
                            MajorVersion = 1,
                            MinorVersion = 1,
                        };
                        blf.ContentFlags |= BlfFileContentFlags.EndOfFile;
                    }

                    variantName = blf.ContentHeader?.Metadata?.Name ?? "";
                }

                var output = GetOutputPath(input, variantName, blf.ContentHeader.Metadata.UniqueId);

                Directory.CreateDirectory(Path.GetDirectoryName(output));

                using (var stream = new FileInfo(output).Create())
                {
                    var writer = new EndianWriter(stream);
                    blf.Write(writer);
                }

                UniqueIdTable.Add(blf.ContentHeader.Metadata.UniqueId);
            }
            catch (Exception e)
            {
                ErrorLog.Add($"Error converting \"{filePath}\" : {e.Message}");
            }
        }

        private void FixBlfEndianness(FileStream stream, Blf blf)
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            using (var memoryStream = new MemoryStream(buffer)) 
            {
                var deserializer = new TagDeserializer(CacheVersion.HaloOnlineED, CachePlatform.Original);
                var serializer = new TagSerializer(CacheVersion.HaloOnlineED, CachePlatform.Original);

                var reader = new EndianReader(memoryStream, EndianFormat.BigEndian);
                var writer = new EndianWriter(memoryStream, EndianFormat.LittleEndian);
                var readerContext = new DataSerializationContext(reader);
                var writerContext = new DataSerializationContext(writer);

                if (reader.ReadTag() != "_blf")
                {
                    memoryStream.Position = 0;

                    ReadBlf(memoryStream, blf);
                }

                reader.BaseStream.Position = 0;

                while (true)
                {
                    var pos = reader.BaseStream.Position;
                    var header = (BlfChunkHeader)deserializer.Deserialize(readerContext, typeof(BlfChunkHeader));

                    writer.BaseStream.Position = pos;
                    serializer.Serialize(writerContext, header);
                    if (header.Signature == "_eof")
                        break;

                    reader.BaseStream.Position += header.Length - (int)TagStructure.GetStructureSize(typeof(BlfChunkHeader), Cache.Version, Cache.Platform);
                }

                memoryStream.Position = 0xC;
                writer.Format = EndianFormat.LittleEndian;
                writer.Write((short)-2);
                memoryStream.Position = 0;

                ReadBlf(memoryStream, blf);
            }
        }

        private void ReadBlf(Stream stream, Blf blf) 
        {
            var memoryReader = new EndianReader(stream);

            if (!blf.Read(memoryReader))
                throw new Exception("Unable to parse BLF data");
        }

        private void Convert06Blf(Blf blf) 
        {
            if (TagMap == null) 
            {
                var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\mappings\061_mapping.json");
                TagMap = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonData);
            }

            blf.MapVariantTagNames = new BlfMapVariantTagNames()
            {
                Signature = new Tag("tagn"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariantTagNames), blf.Version, CachePlatform.Original),
                MajorVersion = 1,
                MinorVersion = 0,
                Names = Enumerable.Range(0, 256).Select(x => new TagName()).ToArray(),
            };
            blf.ContentFlags |= BlfFileContentFlags.MapVariantTagNames;

            for (int i = 0; i < blf.MapVariant.MapVariant.Quotas.Length; i++) 
            {
                var objectIndex = blf.MapVariant.MapVariant.Quotas[i].ObjectDefinitionIndex;

                if (objectIndex != -1 && TagMap.TryGetValue(objectIndex, out string name)) 
                {
                    blf.MapVariantTagNames.Names[i] = new TagName() { Name = name };
                }
            }
        }

        private string GetOutputPath(FileInfo input, string variantName, ulong uniqueId)
        {
            string outputPath = input.Name.EndsWith(".map") ? Path.Combine(OutputPath, $@"map_variants", Regex.Replace($"{variantName.TrimStart().TrimEnd()}", @"[*\\ /:""]", "_"), "sandbox.map") : Path.Combine(OutputPath, $@"game_variants", Regex.Replace($"{variantName.TrimStart().TrimEnd()}", @"[*\\ /:""]", "_"), $@"variant{input.Extension}");

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

            var fileName = Regex.Replace($"hott_{shortDateTime}_variant_errors.log", @"[*\\ /:]", "_");
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