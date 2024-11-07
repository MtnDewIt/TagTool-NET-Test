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
using TagTool.Tags.Definitions.Common;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using TagTool.BlamFile.GameVariants;

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
                using (var stream = input.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    FixBlfEndianness(stream, blf);
                    
                    if (blf.MapVariantTagNames == null && blf.MapVariant != null)
                    {
                        Convert06Blf(blf);
                    }

                    //Convert05Blf(blf);

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
                ErrorLog.Add($"Error converting \"{filePath}\": {e.Message}");
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

        private void Convert05Blf(Blf blf) 
        {
            if (TagMap == null)
            {
                var jsonData = File.ReadAllText($@"{JSONFileTree.JSONBinPath}051_mapping.json");
                TagMap = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonData);
            }

            if (blf.MapVariantTagNames == null && blf.MapVariant != null) 
            {
                // TODO: Add functions to convert object flags and parse legacy object data
                // Really gonna have to dig through unk's old converter to figure out how that's being handled

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

                    for (int j = 0; j < blf.MapVariant.MapVariant.Objects.Length; j++)
                    {
                        var placement = blf.MapVariant.MapVariant.Objects[i];

                        if (objectIndex == 0x444C || objectIndex == 0x4221)
                        {
                            if (placement.QuotaIndex == i)
                            {
                                placement.Properties.Boundary.Type = MultiplayerObjectBoundaryShape.Count;
                            }
                        }

                        if (objectIndex == 0x1A6C) 
                        {
                            // Apparently we're supposed to add the data for the map options object here :/
                        }
                    }

                    if (objectIndex != -1 && TagMap.TryGetValue(objectIndex, out string name))
                    {
                        blf.MapVariantTagNames.Names[i] = new TagName() { Name = name };
                    }
                }
            }

            if (blf.GameVariant != null) 
            {
                var baseVariant = blf.GameVariant.Variant;

                UpdateStartingWeaponData(baseVariant.RespawnOptions.RespawnPlayerTraits.WeaponTraits);
                UpdateStartingWeaponData(baseVariant.MapOverrideOptions.BasePlayerTraits.WeaponTraits);
                UpdateStartingWeaponData(baseVariant.MapOverrideOptions.RedPowerupTraits.WeaponTraits);
                UpdateStartingWeaponData(baseVariant.MapOverrideOptions.BluePowerupTraits.WeaponTraits);
                UpdateStartingWeaponData(baseVariant.MapOverrideOptions.YellowPowerupTraits.WeaponTraits);

                switch (blf.GameVariant.GameVariantType)
                {
                    case GameEngineType.CaptureTheFlag:
                        var ctfVariant = blf.GameVariant.Variant as GameVariantCtf;
                        UpdateStartingWeaponData(ctfVariant.CarrierTraits.WeaponTraits);
                        break;
                    case GameEngineType.Slayer:
                        var slayerVariant = blf.GameVariant.Variant as GameVariantSlayer;
                        UpdateStartingWeaponData(slayerVariant.LeaderTraits.WeaponTraits);
                        break;
                    case GameEngineType.Oddball:
                        var oddballVariant = blf.GameVariant.Variant as GameVariantOddball;
                        UpdateStartingWeaponData(oddballVariant.CarrierTraits.WeaponTraits);
                        break;
                    case GameEngineType.KingOfTheHill:
                        var kothVariant = blf.GameVariant.Variant as GameVariantKing;
                        UpdateStartingWeaponData(kothVariant.InsideHillTraits.WeaponTraits);
                        break;
                    case GameEngineType.Sandbox:
                        var sandboxVariant = blf.GameVariant.Variant as GameVariantSandbox;
                        UpdateStartingWeaponData(sandboxVariant.PlayerTraits.WeaponTraits);
                        break;
                    case GameEngineType.Vip:
                        var vipVariant = blf.GameVariant.Variant as GameVariantVip;
                        UpdateStartingWeaponData(vipVariant.VipTeamTraits.WeaponTraits);
                        UpdateStartingWeaponData(vipVariant.VipInfluenceTraits.WeaponTraits);
                        UpdateStartingWeaponData(vipVariant.VipTraits.WeaponTraits);
                        break;
                    case GameEngineType.Juggernaut:
                        var juggernautVariant = blf.GameVariant.Variant as GameVariantJuggernaut;
                        UpdateStartingWeaponData(juggernautVariant.JuggernautTraits.WeaponTraits);
                        break;
                    case GameEngineType.Territories:
                        var territoriesVariant = blf.GameVariant.Variant as GameVariantTerritories;
                        UpdateStartingWeaponData(territoriesVariant.DefenderTraits.WeaponTraits);
                        UpdateStartingWeaponData(territoriesVariant.AttackerTraits.WeaponTraits);
                        break;
                    case GameEngineType.Assault:
                        var assaultVariant = blf.GameVariant.Variant as GameVariantAssault;
                        UpdateStartingWeaponData(assaultVariant.CarrierTraits.WeaponTraits);
                        UpdateStartingWeaponData(assaultVariant.ArmingTraits.WeaponTraits);
                        break;
                    case GameEngineType.Infection:
                        var infectionVariant = blf.GameVariant.Variant as GameVariantInfection;
                        UpdateStartingWeaponData(infectionVariant.ZombieTraits.WeaponTraits);
                        UpdateStartingWeaponData(infectionVariant.FirstZombieTraits.WeaponTraits);
                        UpdateStartingWeaponData(infectionVariant.SafeHavenDefenderTraits.WeaponTraits);
                        UpdateStartingWeaponData(infectionVariant.LastHumanTraits.WeaponTraits);
                        break;
                }
            }
        }

        private void UpdateStartingWeaponData(GameVariantPlayerTraits.PlayerWeaponTraits weaponTraits) 
        {
            if (weaponTraits.PrimaryWeaponIndex == 67)
                weaponTraits.PrimaryWeaponIndex = 17;

            if (weaponTraits.SecondaryWeaponIndex == 67)
                weaponTraits.SecondaryWeaponIndex = 17;
        }

        private string GetOutputPath(FileInfo input, string variantName, ulong uniqueId)
        {
            string outputPath = input.Name.EndsWith(".map") ? Path.Combine(OutputPath, $@"map_variants", $@"{variantName.TrimEnd()}", "sandbox.map") : Path.Combine(OutputPath, $@"game_variants", $@"{variantName.TrimEnd()}", $@"variant{input.Extension}");

            if (Path.Exists(outputPath) && UniqueIdTable.Contains(uniqueId))
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