using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagTool.BlamFile;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;

namespace TagTool.Commands.Files
{
    public class ConvertToAresVariantCommand : Command
    {
        private GameCache Cache;
        private string OutputPath = "";

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
            ".map",
            ".mvar",
            ".bin",
        };

        private static readonly Dictionary<ContentItemMetadata.ContentItemType, string> ContentTypeToFileExtension = new Dictionary<ContentItemMetadata.ContentItemType, string>()
        {
            [ContentItemMetadata.ContentItemType.None] = ".bin",
            [ContentItemMetadata.ContentItemType.CTF] = ".ctf",
            [ContentItemMetadata.ContentItemType.Slayer] = ".slayer",
            [ContentItemMetadata.ContentItemType.Oddball] = ".oddball",
            [ContentItemMetadata.ContentItemType.King] = ".koth",
            [ContentItemMetadata.ContentItemType.Juggernaut] = ".jugg",
            [ContentItemMetadata.ContentItemType.Territories] = ".terries",
            [ContentItemMetadata.ContentItemType.Assault] = ".assault",
            [ContentItemMetadata.ContentItemType.Infection] = ".zombiez",
            [ContentItemMetadata.ContentItemType.VIP] = ".vip",
            [ContentItemMetadata.ContentItemType.Usermap] = ".map",
        };

        private static readonly Dictionary<int, string> MapIdToMapFile = new Dictionary<int, string>()
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

        public ConvertToAresVariantCommand(GameCache cache) : base
        (
            true,
            "ConvertToAresVariant",
            "Converts all Halo 3 variants in the specified path into Ares Variants",

            "ConvertToAresVariant <input directory> [output directory]",
            "Converts all Halo 3 variants in the specified path into Ares Variants"
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

            long streamLength = 0;
            string variantName = "";
            ulong uniqueId = 0;
            ContentItemMetadata.ContentItemType contentType = ContentItemMetadata.ContentItemType.None;

            try
            {
                using (var stream = input.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    ReadBlf(stream, blf);

                    Dictionary<int, string> aresMapping = GetAresMapping(blf.MapVariant.MapVariant.MapId);
                    Dictionary<int, string> x360Mapping = GetX360Mapping(blf.MapVariant.MapVariant.MapId);

                    blf.MapVariant.MapVariant.VariantVersion = 12;

                    // This is the checksum of empty RSA
                    blf.MapVariant.MapVariant.OriginalMapRSASignatureHash = 0xF2697AA7;

                    // Force a unique id by xor'ing the timestamp and the xuid (only if either chunk lacks a unique id)
                    if (blf.ContentHeader.Metadata.UniqueId == 0) 
                    {
                        blf.ContentHeader.Metadata.UniqueId = blf.ContentHeader.Metadata.Timestamp ^ blf.ContentHeader.Metadata.AuthorId;
                    }

                    if (blf.MapVariant.MapVariant.Metadata.UniqueId == 0) 
                    {
                        blf.MapVariant.MapVariant.Metadata.UniqueId = blf.MapVariant.MapVariant.Metadata.Timestamp ^ blf.MapVariant.MapVariant.Metadata.AuthorId;
                    }

                    /*
                    short newObjectCount = 0;
                    VariantObjectDatum[] newObjectList = new VariantObjectDatum[640];

                    for (int i = 0; i < blf.MapVariant.MapVariant.ObjectTypeStartIndex.Length; i++)
                    {
                        if (blf.MapVariant.MapVariant.ObjectTypeStartIndex[i] != -1)
                        {
                            blf.MapVariant.MapVariant.ObjectTypeStartIndex[i] = (short)i;
                            newObjectCount++;
                        }
                        else
                        {
                            blf.MapVariant.MapVariant.ObjectTypeStartIndex[i] = -1;
                        }
                    }

                    blf.MapVariant.MapVariant.ScenarioObjectCount = newObjectCount;

                    for (int i = newObjectCount; i < blf.MapVariant.MapVariant.Objects.Length; i++) 
                    {
                        if (blf.MapVariant.MapVariant.Objects[i].Flags.HasFlag(VariantObjectDatum.VariantObjectPlacementFlags.Edited))
                        {
                            newObjectList[newObjectCount] = blf.MapVariant.MapVariant.Objects[i];
                            newObjectList[newObjectCount].Flags &= ~VariantObjectDatum.VariantObjectPlacementFlags.ScenarioObject;
                            newObjectCount++;
                        }

                        blf.MapVariant.MapVariant.ObjectTypeStartIndex[i] += newObjectCount;
                    }

                    blf.MapVariant.MapVariant.VariantObjectCount = newObjectCount;
                    blf.MapVariant.MapVariant.Objects = newObjectList;
                    */

                    for (int i = 0; i < blf.MapVariant.MapVariant.Quotas.Length; i++) 
                    {
                        if (blf.MapVariant.MapVariant.Quotas[i].ObjectDefinitionIndex > 0)
                        {
                            string x360ObjectTag = x360Mapping[blf.MapVariant.MapVariant.Quotas[i].ObjectDefinitionIndex];
                            int aresObjectIndex = aresMapping.FirstOrDefault(x => string.Equals(x.Value, x360ObjectTag)).Key;

                            string aresObjectTag = aresMapping[aresObjectIndex];
                            Debug.Assert(string.Equals(x360ObjectTag, aresObjectTag));

                            blf.MapVariant.MapVariant.Quotas[i].ObjectDefinitionIndex = aresObjectIndex;
                        }
                        else 
                        {
                            blf.MapVariant.MapVariant.Quotas[i].ObjectDefinitionIndex = -1;
                        }

                        blf.MapVariant.MapVariant.Quotas[i].PlacedOnMap = 0;
                        blf.MapVariant.MapVariant.Quotas[i].MaximumCount = 0;
                        blf.MapVariant.MapVariant.Quotas[i].MaxAllowed = 0;
                        blf.MapVariant.MapVariant.Quotas[i].Cost = 0.0f;
                    }

                    streamLength = stream.Length;
                    uniqueId = blf.ContentHeader?.Metadata?.UniqueId ?? 0;
                    variantName = blf.ContentHeader?.Metadata?.Name ?? "";
                    contentType = blf.ContentHeader?.Metadata?.ContentType ?? ContentItemMetadata.ContentItemType.None;
                }

                var output = GetOutputPath(variantName, contentType, uniqueId);

                Directory.CreateDirectory(Path.GetDirectoryName(output));

                using (var stream = new FileInfo(output).Create())
                {
                    ByteSwapAndWrite(stream, streamLength, blf);
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

        private void ByteSwapAndWrite(FileStream stream, long streamLength, Blf blf)
        {
            var buffer = new byte[streamLength];

            using (var memoryStream = new MemoryStream(buffer)) 
            {
                var writer = new EndianWriter(memoryStream, EndianFormat.LittleEndian);
                var writerContext = new DataSerializationContext(writer);

                blf.Format = EndianFormat.LittleEndian;
                blf.StartOfFile?.ByteSwap();
                blf.Author?.ByteSwap();
                blf.ContentHeader?.ByteSwap();
                blf.GameVariant?.ByteSwap();
                blf.MapVariant?.ByteSwap();
                blf.EndOfFile?.ByteSwap();

                blf.Write(writer);

                stream.Write(buffer);
            }
        }

        private void ReadBlf(Stream stream, Blf blf)
        {
            var memoryReader = new EndianReader(stream);

            if (!blf.Read(memoryReader))
                throw new Exception("Unable to parse BLF data");
        }

        private Dictionary<int, string> GetAresMapping(int mapId)
        {
            string mappingPath = $"{DirectoryPaths.Data}\\mappings\\h3_ares\\{MapIdToMapFile[mapId]}_mappings.json";

            // INSERT FILE CHECK

            return JsonConvert.DeserializeObject<Dictionary<int, string>>(File.ReadAllText(mappingPath));
        }

        private Dictionary<int, string> GetX360Mapping(int mapId)
        {
            string mappingPath = $"{DirectoryPaths.Data}\\mappings\\h3_360\\{MapIdToMapFile[mapId]}_mappings.json";

            // INSERT FILE CHECK

            return JsonConvert.DeserializeObject<Dictionary<int, string>>(File.ReadAllText(mappingPath));
        }

        private string GetOutputPath(string variantName, ContentItemMetadata.ContentItemType contentType, ulong uniqueId)
        {
            var filteredName = Regex.Replace($"{variantName.TrimStart().TrimEnd().TrimEnd('.')}", @"[<>:""/\|?*]", "_");

            string outputPath = contentType == ContentItemMetadata.ContentItemType.Usermap ? Path.Combine(OutputPath, $@"map_variants", filteredName, $@"sandbox{ContentTypeToFileExtension[contentType]}") : Path.Combine(OutputPath, $@"game_variants", filteredName, $@"variant{ContentTypeToFileExtension[contentType]}");

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
            var fullPath = Path.Combine(DirectoryPaths.Base, filePath, fileName);

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
