using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagTool.BlamFile;
using TagTool.BlamFile.Reach;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Files
{
    public class ConvertReachMapVariantCommand : Command
    {
        private readonly GameCacheHaloOnlineBase Cache;

        private string OutputPath = "";

        private Stopwatch StopWatch = new Stopwatch();
        private int FileCount = 0;
        private List<string> ErrorLog = new List<string>();
        private List<ulong> UniqueIdTable = new List<ulong>();

        private static readonly string[] ValidExtensions =
        {
            ".map",
            ".mvar",
        };

        public ConvertReachMapVariantCommand(GameCacheHaloOnlineBase cache)
            : base(true,

                  "ConvertReachMapVariant",
                  "Converts all reach map variants in the specified path",

                  "ConvertReachMapVariant <maps directory> <input directory> [output directory]",
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
            Blf convertedBlf = null;

            var variantName = "";

            try 
            {
                Dictionary<Tag, BlfChunk> blfChunks;
                using (var inputStream = input.OpenRead())
                    blfChunks = BlfReader.ReadChunks(inputStream).ToDictionary(c => c.Tag);

                if (blfChunks.ContainsKey("mvar"))
                {
                    convertedBlf = ConvertMapVariant(mapsDirectory, blfChunks["mvar"]);
                }
                else if (blfChunks.ContainsKey("_cmp"))
                {
                    var decompressed = DecompressChunk(blfChunks["_cmp"]);
                    var chunk = BlfReader.ReadChunks(new MemoryStream(decompressed)).First();
                    if (chunk.Tag != "mvar")
                        throw new Exception("Unsupported input file");

                    convertedBlf = ConvertMapVariant(mapsDirectory, chunk);
                }
                else
                {
                    throw new Exception("Unsupported input file");
                }

                if (convertedBlf == null)
                    throw new Exception("Failed to convert map variant");

                variantName = convertedBlf?.ContentHeader?.Metadata?.Name ?? "";

                var output = GetOutputPath(input, variantName, convertedBlf.ContentHeader.Metadata.UniqueId);

                Directory.CreateDirectory(Path.GetDirectoryName(output));

                using (var stream = new FileInfo(output).Create())
                {
                    var writer = new EndianWriter(stream);
                    convertedBlf.Write(writer);
                }

                UniqueIdTable.Add(convertedBlf.ContentHeader.Metadata.UniqueId);
            }
            catch (Exception e)
            {
                ErrorLog.Add($"Error converting \"{filePath}\" : {e.Message}");
            }
        }

        private Blf ConvertMapVariant(DirectoryInfo mapsDirectory, BlfChunk chunk)
        {
            var stream = new MemoryStream(chunk.Data);

            if (chunk.MajorVerson == 31)
            {
                return ConvertReachMapVariant(stream, mapsDirectory);
            }
            else
            {
                throw new Exception("Unsupported Map Variant version");
            }
        }

        private Blf ConvertReachMapVariant(MemoryStream stream, DirectoryInfo mapsDirectory)
        {
            var sourceBlf = new ReachBlfMapVariant();
            sourceBlf.Decode(stream);

            int mapId = sourceBlf.MapVariant.MapId;
            var sourceCache = GetMapCache(mapsDirectory, mapId);
            if (sourceCache == null)
                return null;

            var sourceCacheStream = sourceCache.OpenCacheRead();
            var sourceScenario = sourceCache.Deserialize<Scenario>(sourceCacheStream, sourceCache.TagCache.FindFirstInGroup("scnr"));
            if (sourceScenario.MapId != mapId)
            {
                throw new Exception($"Scenario map id did not match");
            }

            var converter = new ReachMapVariantConverter();

            // hardcode for now
            converter.SubstitutedTags.Add(@"objects\vehicles\human\warthog\warthog.vehi", @"objects\vehicles\warthog\warthog.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\human\mongoose\mongoose.vehi", @"objects\vehicles\mongoose\mongoose.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\human\scorpion\scorpion.vehi", @"objects\vehicles\scorpion\scorpion.vehi");
            //converter.SubstitutedTags.Add(@"objects\vehicles\human\falcon\falcon.vehi", @"objects\vehicles\hornet\hornet.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\covenant\ghost\ghost.vehi", @"objects\vehicles\ghost\ghost.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\covenant\wraith\wraith.vehi", @"objects\vehicles\wraith\wraith.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\covenant\banshee\banshee.vehi", @"objects\vehicles\banshee\banshee.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\human\turrets\machinegun\machinegun.vehi", @"objects\weapons\turret\machinegun_turret\machinegun_turret.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\covenant\turrets\plasma_turret\plasma_turret_mounted.vehi", @"objects\weapons\turret\plasma_cannon\plasma_cannon.vehi");
            converter.SubstitutedTags.Add(@"objects\vehicles\covenant\turrets\shade\shade.vehi", @"objects\vehicles\shade\shade.vehi");
            //converter.SubstitutedTags.Add(@"objects\vehicles\covenant\revenant\revenant.vehi", @"objects\vehicles\ghost\ghost.vehi");

            converter.SubstitutedTags.Add(@"objects\equipment\hologram\hologram.eqip", @"objects\equipment\hologram_equipment\hologram_equipment.eqip");
            converter.SubstitutedTags.Add(@"objects\equipment\active_camouflage\active_camouflage.eqip", @"objects\equipment\invisibility_equipment\invisibility_equipment.eqip");

            converter.SubstitutedTags.Add(@"objects\weapons\melee\energy_sword\energy_sword.weap", @"objects\weapons\melee\energy_blade\energy_blade.weap");
            converter.SubstitutedTags.Add(@"objects\levels\shared\golf_club\golf_club.weap", @"objects\weapons\melee\gravity_hammer\gravity_hammer.weap");

            converter.SubstitutedTags.Add(@"objects\multi\models\mp_hill_beacon\mp_hill_beacon.bloc", @"objects\multi\koth\koth_hill_static.bloc");
            converter.SubstitutedTags.Add(@"objects\multi\models\mp_flag_base\mp_flag_base.bloc", @"objects\multi\ctf\ctf_flag_spawn_point.bloc");
            converter.SubstitutedTags.Add(@"objects\multi\models\mp_circle\mp_circle.bloc", @"objects\multi\oddball\oddball_ball_spawn_point.bloc");
            converter.SubstitutedTags.Add(@"objects\multi\archive\vip\vip_boundary.bloc", @"objects\multi\vip\vip_destination_static.bloc");

            converter.ExcludedTags.Add(@"objects\multi\spawning\weak_anti_respawn_zone.scen");
            converter.ExcludedTags.Add(@"objects\multi\spawning\weak_respawn_zone.scen");
            converter.ExcludedTags.Add(@"objects\multi\boundaries\soft_safe_volume.scen");
            converter.ExcludedTags.Add(@"objects\multi\boundaries\soft_kill_volume.scen");
            converter.ExcludedTags.Add(@"objects\multi\boundaries\kill_volume.scen");
            //converter.ExcludedTags.Add(@"objects\multi\spawning\respawn_zone.scen");

            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\juicy.bloc");
            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\colorblind.bloc");
            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\dusk.bloc");
            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\golden_hour.bloc");
            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\gloomy.bloc");
            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\olde_timey.bloc");
            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\eerie.bloc");
            converter.ExcludedTags.Add(@"objects\levels\shared\screen_fx_orb\fx\pen_and_ink.bloc");

            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_flash_yellow\ff_light_flash_yellow.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_flash_red\ff_light_flash_red.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_red\ff_light_red.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_white\ff_light_white.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_green\ff_light_green.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_yellow\ff_light_yellow.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_orange\ff_light_orange.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_purple\ff_light_purple.bloc");
            //converter.ExcludedTags.Add(@"objects\levels\forge\ff_light_blue\ff_light_blue.bloc");

            converter.ExcludedTags.Add(@"objects\equipment\jet_pack\jet_pack.eqip");
            converter.ExcludedTags.Add(@"objects\equipment\sprint\sprint.eqip");
            converter.ExcludedTags.Add(@"objects\equipment\evade\evade.eqip");

            converter.ExcludedMegaloLabels.Add("hh_drop_point");
            converter.ExcludedMegaloLabels.Add("inv_cinematic");
            converter.ExcludedMegaloLabels.Add("inv_gates");
            converter.ExcludedMegaloLabels.Add("inv_mancannon");
            converter.ExcludedMegaloLabels.Add("inv_no_core_zone");
            converter.ExcludedMegaloLabels.Add("inv_obj_flag");
            converter.ExcludedMegaloLabels.Add("inv_objective");
            converter.ExcludedMegaloLabels.Add("inv_platform");
            converter.ExcludedMegaloLabels.Add("inv_res_p1");
            converter.ExcludedMegaloLabels.Add("inv_res_p2");
            converter.ExcludedMegaloLabels.Add("inv_res_p3");
            converter.ExcludedMegaloLabels.Add("inv_res_zone");
            converter.ExcludedMegaloLabels.Add("inv_slayer");
            converter.ExcludedMegaloLabels.Add("inv_slayer_drop");
            converter.ExcludedMegaloLabels.Add("inv_slayer_res_zone");
            converter.ExcludedMegaloLabels.Add("inv_vehicle");
            converter.ExcludedMegaloLabels.Add("inv_weapon");
            converter.ExcludedMegaloLabels.Add("invasion");
            converter.ExcludedMegaloLabels.Add("invasion_slayer");
            converter.ExcludedMegaloLabels.Add("race");
            converter.ExcludedMegaloLabels.Add("race_flag");
            converter.ExcludedMegaloLabels.Add("rally");
            converter.ExcludedMegaloLabels.Add("rally_flag");
            converter.ExcludedMegaloLabels.Add("stockpile");
            converter.ExcludedMegaloLabels.Add("stockpile_flag");
            converter.ExcludedMegaloLabels.Add("stp_flag");
            converter.ExcludedMegaloLabels.Add("stp_goal");

            return converter.Convert(sourceScenario, sourceBlf);
        }

        private GameCache GetMapCache(DirectoryInfo mapsDirectory, int mapId)
        {
            var mapFile = new FileInfo(Path.Combine(mapsDirectory.FullName, $"{MapIdToFilename[mapId]}.map"));
            if (!mapFile.Exists)
            {
                throw new Exception($"'${MapIdToFilename[mapId]}.map' could not be found.");
            }
            return GameCache.Open(mapFile);
        }

        private static byte[] DecompressChunk(BlfChunk cmpChunk)
        {
            var stream = new MemoryStream(cmpChunk.Data);
            var reader = new EndianReader(stream, EndianFormat.BigEndian);
            var compressionType = reader.ReadSByte();
            if (compressionType != 0)
                throw new NotSupportedException();

            var size = reader.ReadInt32();
            reader.ReadBytes(2); // skip header
            var compressed = reader.ReadBytes(size - 2);
            return Decompress(compressed);
        }

        static byte[] Decompress(byte[] compressed)
        {
            using (var stream = new DeflateStream(new MemoryStream(compressed), CompressionMode.Decompress))
            {
                var outStream = new MemoryStream();
                stream.CopyTo(outStream);
                return outStream.ToArray();
            }
        }

        private string GetOutputPath(FileInfo input, string variantName, ulong uniqueId)
        {
            string outputPath = Path.Combine(OutputPath, $@"map_variants", Regex.Replace($"{variantName.TrimStart().TrimEnd()}", @"[*\\ /:""]", "_"), "sandbox.map");

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

        private static readonly Dictionary<int, string> MapIdToFilename = new Dictionary<int, string>()
        {
            [1000] = "20_sword_slayer",
            [1020] = "45_launch_station",
            [1035] = "50_panopticon",
            [1040] = "45_aftship",
            [1055] = "30_settlement",
            [1080] = "70_boneyard",
            [1150] = "52_ivory_tower",
            [1200] = "35_island",
            [1500] = "condemned",
            [1510] = "trainingpreserve",
            [2001] = "dlc_slayer",
            [2002] = "dlc_invasion",
            [2004] = "dlc_medium",
            [3006] = "forge_halo",
            [10010] = "cex_damnation",
            [10020] = "cex_beaver_creek",
            [10030] = "cex_timberland",
            [10050] = "cex_headlong",
            [10060] = "cex_hangemhigh",
            [10070] = "cex_prisoner",
        };
    }
}
