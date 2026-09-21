using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagTool.BlamFile;
using TagTool.BlamFile.Chunks;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

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

            string variantName = "";
            ulong uniqueId = 0;
            ContentItemMetadata.ContentItemType contentType = ContentItemMetadata.ContentItemType.None;

            try
            {
                using (var stream = input.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    ReadBlf(stream, blf);

                    if (blf?.MapVariant != null) 
                    {
                        Dictionary<int, string> aresMapping = GetAresMapping(blf.MapVariant.MapVariant.MapId);
                        Dictionary<int, string> x360Mapping = GetX360Mapping(blf.MapVariant.MapVariant.MapId);
                        Dictionary<(VariantObjectQuota.MapVariantQuotaPalette, short), string> mccMapping = GetMCCMapping(blf.MapVariant.MapVariant.MapId);

                        // This is the checksum of empty RSA
                        blf?.MapVariant?.MapVariant?.OriginalMapRSASignatureHash = 0xF2697AA7;

                        // Force a unique id by xor'ing the timestamp and the xuid (only if either chunk lacks a unique id)
                        if (blf?.ContentHeader?.Metadata?.UniqueId == 0)
                        {
                            blf?.ContentHeader?.Metadata?.UniqueId = blf.ContentHeader.Metadata.Timestamp ^ blf.ContentHeader.Metadata.AuthorId;
                        }

                        if (blf?.MapVariant?.MapVariant?.Metadata?.UniqueId == 0)
                        {
                            blf?.MapVariant?.MapVariant?.Metadata?.UniqueId = blf.MapVariant.MapVariant.Metadata.Timestamp ^ blf.MapVariant.MapVariant.Metadata.AuthorId;
                        }

                        if (blf?.MapVariant?.MapVariant?.VariantVersion == 13 || blf?.MapVariant?.MapVariant?.VariantVersion == 14)
                        {
                            List<VariantObjectDatum> objectList = [.. blf.MapVariant.MapVariant.Objects];
                            List<VariantObjectQuota> quotaList = [.. blf.MapVariant.MapVariant.Quotas];

                            List<int> badBudgetIndices = [];
                            List<int> badBoundaryIndices = [];

                            for (int i = blf.MapVariant.MapVariant.PlaceableQuotaCount - 1; i >= 0; i--)
                            {
                                int aresObjectIndex = -1;

                                if (mccMapping.TryGetValue((quotaList[i].TagBlockIndex, quotaList[i].TagBlockElementIndex), out string mccObjectTag))
                                {
                                    var aresMatch = aresMapping.FirstOrDefault(x => string.Equals(x.Value, mccObjectTag));

                                    if (!string.IsNullOrEmpty(aresMatch.Value))
                                    {
                                        aresObjectIndex = aresMatch.Key;
                                    }
                                    else
                                    {
                                        ErrorLog.Add($"WARNING: Object Mismatch {mccObjectTag}");
                                    }
                                }

                                if (aresObjectIndex != -1)
                                {
                                    quotaList[i].ObjectDefinitionIndex = aresObjectIndex;
                                }
                                else
                                {
                                    quotaList.RemoveAt(i);
                                    quotaList.Add(new VariantObjectQuota());
                                    blf.MapVariant.MapVariant.PlaceableQuotaCount -= 1;
                                    badBudgetIndices.Add(i);
                                }
                            }

                            for (int i = 0; i < quotaList.Count; i++)
                            {
                                if (quotaList[i].TagBlockIndex == VariantObjectQuota.MapVariantQuotaPalette.Goal ||
                                    quotaList[i].TagBlockIndex == VariantObjectQuota.MapVariantQuotaPalette.Teleporter)
                                {
                                    badBoundaryIndices.Add(i);
                                }

                                quotaList[i].PlacedOnMap = 0;
                                quotaList[i].MaximumCount = 0;
                                quotaList[i].MaxAllowed = 0;
                                quotaList[i].Cost = 0.0f;
                            }

                            int removedObjectsCount = 0;

                            for (int i = blf.MapVariant.MapVariant.VariantObjectCount - 1; i >= 0; i--)
                            {
                                if (badBudgetIndices.Contains(objectList[i].QuotaIndex))
                                {
                                    objectList.RemoveAt(i);
                                    objectList.Add(new VariantObjectDatum());
                                    blf?.MapVariant?.MapVariant?.VariantObjectCount -= 1;
                                    removedObjectsCount += 1;
                                }
                            }

                            if (removedObjectsCount > 0)
                            {
                                ErrorLog.Add($"WARNING: {blf.MapVariant.MapVariant.Metadata.Name}: {removedObjectsCount} objects have been removed.");
                            }

                            foreach (int badIndex in badBudgetIndices)
                            {
                                for (int i = 0; i < blf?.MapVariant?.MapVariant?.VariantObjectCount; i++)
                                {
                                    if (objectList[i].QuotaIndex > badIndex)
                                    {
                                        objectList[i].QuotaIndex -= 1;
                                    }
                                }
                            }

                            for (int i = 0; i < objectList.Count; i++)
                            {
                                if (!objectList[i].Flags.HasFlag(VariantObjectDatum.VariantObjectPlacementFlags.None) && quotaList[objectList[i].QuotaIndex].ObjectDefinitionIndex == 0) 
                                {
                                    objectList[i].ObjectIndex = -1;
                                    quotaList[objectList[i].QuotaIndex].ObjectDefinitionIndex = -1;
                                }

                                if (badBoundaryIndices.Contains(objectList[i].QuotaIndex))
                                {
                                    objectList[i].Properties?.Boundary?.NegativeHeight = 1.0f;
                                }
                            }

                            blf?.MapVariant?.MapVariant?.Objects = [.. objectList];
                            blf?.MapVariant?.MapVariant?.Quotas = [.. quotaList];

                            blf?.MapVariant?.MapVariant?.VariantVersion = 12;
                        }
                        else
                        {
                            for (int i = 0; i < blf?.MapVariant?.MapVariant?.Quotas.Length; i++)
                            {
                                // Object definition indices are datum indices (tag indices) stored as negative
                                // 32-bit values in the BLF. Empty quota slots are stored as 0, not -1.
                                if (blf?.MapVariant?.MapVariant?.Quotas[i].ObjectDefinitionIndex != 0)
                                {
                                    if (x360Mapping.TryGetValue(blf.MapVariant.MapVariant.Quotas[i].ObjectDefinitionIndex, out string x360ObjectTag))
                                    {
                                        int aresObjectIndex = aresMapping.FirstOrDefault(x => string.Equals(x.Value, x360ObjectTag)).Key;

                                        string aresObjectTag = aresMapping.GetValueOrDefault(aresObjectIndex);

                                        if (!string.Equals(x360ObjectTag, aresObjectTag))
                                        {
                                            ErrorLog.Add($"WARNING: Object Mismatch {x360ObjectTag} != {aresObjectTag}");
                                        }

                                        blf?.MapVariant?.MapVariant?.Quotas[i].ObjectDefinitionIndex = aresObjectIndex;
                                    }
                                }
                                else
                                {
                                    blf?.MapVariant?.MapVariant?.Quotas[i].ObjectDefinitionIndex = 0;
                                }

                                blf?.MapVariant?.MapVariant?.Quotas[i].PlacedOnMap = 0;
                                blf?.MapVariant?.MapVariant?.Quotas[i].MaximumCount = 0;
                                blf?.MapVariant?.MapVariant?.Quotas[i].MaxAllowed = 0;
                                blf?.MapVariant?.MapVariant?.Quotas[i].Cost = 0.0f;
                            }
                        }

                        blf?.MapVariant?.MapVariant?.VariantVersion = 12;
                    }

                    blf?.StartOfFile?.FileType = string.Empty;

                    blf?.Version = CacheVersion.Halo3Retail;
                    blf?.CachePlatform = CachePlatform.Original;

                    if (blf.ContentFlags.HasFlag(Blf.BlfFileContentFlags.Author)) 
                    {
                        blf.ContentFlags &= ~Blf.BlfFileContentFlags.Author;
                        blf.ContentFlags |= Blf.BlfFileContentFlags.ContentHeader;
                        blf.Author = null;

                        blf.ContentHeader = new BlfContentHeader
                        {
                            Signature = new Tag("chdr"),
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfContentHeader), blf.Version, blf.CachePlatform),
                            MajorVersion = 9,
                            MinorVersion = 2,
                            BuildVersion = -1,
                            MapMinorVersion = 0,
                            Metadata = blf?.MapVariant?.MapVariant?.Metadata
                        };
                    }

                    if (blf.ContentFlags.HasFlag(Blf.BlfFileContentFlags.PackedMapVariant))
                    {
                        blf.ContentFlags &= ~Blf.BlfFileContentFlags.PackedMapVariant;
                        blf.ContentFlags |= Blf.BlfFileContentFlags.MapVariant;
                        blf.MapVariant.Signature = new Tag("mapv");
                        blf.MapVariant.Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariant), blf.Version, blf.CachePlatform);

                        VariantObjectDatum[] newObjectList = new VariantObjectDatum[640];

                        for (int i = 0; i < blf.MapVariant.MapVariant.Objects.Length; i++) 
                        {
                            newObjectList[i] = blf.MapVariant.MapVariant.Objects[i];
                        }

                        blf.MapVariant.MapVariant.Objects = newObjectList;

                        VariantObjectQuota[] newQuotaList = new VariantObjectQuota[256];

                        for (int i = 0; i < blf.MapVariant.MapVariant.Quotas.Length; i++)
                        {
                            newQuotaList[i] = blf.MapVariant.MapVariant.Quotas[i];
                        }

                        blf.MapVariant.MapVariant.Quotas = newQuotaList;
                    }

                    if (blf.ContentFlags.HasFlag(Blf.BlfFileContentFlags.PackedGameVariant))
                    {
                        blf.ContentFlags &= ~Blf.BlfFileContentFlags.PackedGameVariant;
                        blf.ContentFlags |= Blf.BlfFileContentFlags.GameVariant;
                        blf.GameVariant.Signature = new Tag("mpvr");
                        blf.GameVariant.Length = (int)TagStructure.GetStructureSize(typeof(BlfGameVariant), blf.Version, blf.CachePlatform);

                        // #TODO: We may need to account for packed data here
                    }

                    if (blf.ContentFlags.HasFlag(Blf.BlfFileContentFlags.FileshareMetadata)) 
                    {
                        blf.ContentFlags &= ~Blf.BlfFileContentFlags.FileshareMetadata;
                        blf.FileshareMetadata = null;
                    }

                    uniqueId = blf.ContentHeader?.Metadata?.UniqueId ?? 0;
                    variantName = blf.ContentHeader?.Metadata?.Name ?? "";
                    contentType = blf.ContentHeader?.Metadata?.ContentType ?? ContentItemMetadata.ContentItemType.None;
                }

                var output = GetOutputPath(variantName, contentType, uniqueId);

                Directory.CreateDirectory(Path.GetDirectoryName(output));

                using (var stream = new FileInfo(output).Create())
                {
                    ByteSwapAndWrite(stream, blf);
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

        private void ByteSwapAndWrite(FileStream stream, Blf blf)
        {
            var buffer = new byte[blf.GetVariantFileSize()];

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

            if (!File.Exists(mappingPath))
                throw new FileNotFoundException();

            return JsonConvert.DeserializeObject<Dictionary<int, string>>(File.ReadAllText(mappingPath));
        }

        private Dictionary<int, string> GetX360Mapping(int mapId)
        {
            string mappingPath = $"{DirectoryPaths.Data}\\mappings\\h3_360\\{MapIdToMapFile[mapId]}_mappings.json";

            if (!File.Exists(mappingPath))
                throw new FileNotFoundException();

            return JsonConvert.DeserializeObject<Dictionary<int, string>>(File.ReadAllText(mappingPath));
        }

        private Dictionary<(VariantObjectQuota.MapVariantQuotaPalette, short), string> GetMCCMapping(int mapId)
        {
            string mappingPath = $"{DirectoryPaths.Data}\\mappings\\h3_mcc\\{MapIdToMapFile[mapId]}_mappings.json";

            if (!File.Exists(mappingPath))
                throw new FileNotFoundException();

            var rawDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(mappingPath));
            var resultDict = new Dictionary<(VariantObjectQuota.MapVariantQuotaPalette, short), string>();

            if (rawDict == null)
                return resultDict;

            foreach (var kvp in rawDict)
            {
                string cleanKey = kvp.Key.Trim('(', ')');
                string[] parts = cleanKey.Split(',');

                if (parts.Length != 2)
                    throw new FormatException($"Invalid tuple key format in JSON: {kvp.Key}");

                var palette = Enum.Parse<VariantObjectQuota.MapVariantQuotaPalette>(parts[0].Trim(), ignoreCase: true);
                short index = short.Parse(parts[1].Trim());

                resultDict[(palette, index)] = kvp.Value;
            }

            return resultDict;
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
