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
            if (Cache.Version != CacheVersion.HaloOnlineED) 
            {
                new TagToolError(CommandError.CacheUnsupported, $"Unsupported Cache Version: {Cache.Version}");
            }

            OutputPath = args.Count > 1 ? args[1] : "";
            ProcessDirectoryAsync(args[0]).GetAwaiter().GetResult();

            Console.WriteLine($"{FileCount - ErrorLog.Count}/{FileCount} Variants Converted Successfully in {StopWatch.ElapsedMilliseconds.FormatMilliseconds()}\n");
            Console.WriteLine($"ERROR LOG:");

            foreach (var error in ErrorLog) 
            {
                Console.WriteLine(error);
            }

            return true;
        }

        public async Task ProcessDirectoryAsync(string targetDirectory)
        {
            StopWatch.Start();

            var files = Directory.EnumerateFiles(targetDirectory, "*.*", SearchOption.AllDirectories).Where(file => ValidExtensions.Contains(Path.GetExtension(file).ToLower()));

            FileCount = files.Count();

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
                using (var stream = input.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    var reader = new EndianReader(stream);

                    FixBlfEndianness(stream);

                    if (!blf.Read(reader))
                        throw new Exception("Unable to parse BLF variant");

                    if (blf.MapVariantTagNames == null && blf.MapVariant != null)
                    {
                        ConvertBlf(blf);
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

                var output = GetOutputPath(input, variantName);

                Directory.CreateDirectory(Path.GetDirectoryName(output));

                using (var stream = new FileInfo(output).Create())
                {
                    var writer = new EndianWriter(stream);
                    blf.Write(writer);
                }
            }
            catch (Exception e)
            {
                ErrorLog.Add($"Error converting \"{filePath}\": {e.Message}");
            }
        }

        // TODO: Enure that no data is written back to the original file, and that only the contents of the file stream are modified
        private void FixBlfEndianness(Stream stream)
        {
            var deserializer = new TagDeserializer(CacheVersion.HaloOnlineED, CachePlatform.Original);
            var serializer = new TagSerializer(CacheVersion.HaloOnlineED, CachePlatform.Original);

            var reader = new EndianReader(stream, EndianFormat.BigEndian);
            var writer = new EndianWriter(stream, EndianFormat.LittleEndian);
            var readerContext = new DataSerializationContext(reader);
            var writerContext = new DataSerializationContext(writer);

            if(reader.ReadTag() != "_blf")
            {
                stream.Position = 0;
                return;
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

            stream.Position = 0xC;
            writer.Format = EndianFormat.LittleEndian;
            writer.Write((short)-2);
            stream.Position = 0;
        }

        private void ConvertBlf(Blf blf) 
        {
            if (TagMap == null) 
            {
                var jsonData = File.ReadAllText($@"{JSONFileTree.JSONBinPath}061_mapping.json");
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

        private string GetOutputPath(FileInfo input, string variantName)
        {
            string outputPath = input.Name.EndsWith(".map") ? Path.Combine(OutputPath, $@"map_variants", $@"{variantName}", "sandbox.map") : Path.Combine(OutputPath, $@"game_variants", $@"{variantName}", $@"variant{input.Extension}");

            if (Path.Exists(outputPath))
            {
                throw new Exception("Duplicate Variant");
            }
            else 
            {
                return outputPath;
            }
        }
    }
}