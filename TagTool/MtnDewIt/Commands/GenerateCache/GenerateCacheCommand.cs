using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public static DirectoryInfo eldewritoDirectoryInfo { get; set; }
        public static DirectoryInfo halo3DirectoryInfo { get; set; }
        public static DirectoryInfo halo3MythicDirectoryInfo { get; set; }
        public static DirectoryInfo halo3ODSTDirectoryInfo { get; set; }
        public static DirectoryInfo outputDirectoryInfo { get; set; }

        public GameCache ed_cache { get; set; }
        public static GameCache ho_cache { get; set; }

        public GameCache h3_mainmenu { get; set; }
        public GameCache intro { get; set; }
        public GameCache jungle { get; set; }
        public GameCache crows { get; set; }
        public GameCache outskirts { get; set; }
        public GameCache voi { get; set; }
        public GameCache floodvoi { get; set; }
        public GameCache waste { get; set; }
        public GameCache citadel { get; set; }
        public GameCache highCharity { get; set; }
        public GameCache halo { get; set; }
        public GameCache epilogue { get; set; } 

        public GameCache mythic_mainmenu { get; set; }
        public GameCache armory { get; set; }
        public GameCache bunkerworld { get; set; }
        public GameCache chill { get; set; }
        public GameCache chillout { get; set; }
        public GameCache construct { get; set; }
        public GameCache cyberdyne { get; set; }
        public GameCache deadlock { get; set; }
        public GameCache descent { get; set; }
        public GameCache docks { get; set; }
        public GameCache fortress { get; set; }
        public GameCache ghosttown { get; set; }
        public GameCache guardian { get; set; }
        public GameCache isolation { get; set; }
        public GameCache lockout { get; set; }
        public GameCache midship { get; set; }
        public GameCache riverworld { get; set; }
        public GameCache salvation { get; set; }
        public GameCache sandbox { get; set; }
        public GameCache shrine { get; set; }
        public GameCache sidewinder { get; set; }
        public GameCache snowbound { get; set; }
        public GameCache spacecamp { get; set; }
        public GameCache warehouse { get; set; }
        public GameCache zanzibar { get; set; }

        public GameCache odst_mainmenu { get; set; }
        public GameCache h100 { get; set; }
        public GameCache c100 { get; set; }
        public GameCache c200 { get; set; }
        public GameCache l200 { get; set; }
        public GameCache l300 { get; set; }
        public GameCache sc100 { get; set; }
        public GameCache sc110 { get; set; }
        public GameCache sc120 { get; set; }
        public GameCache sc130 { get; set; }
        public GameCache sc140 { get; set; }
        public GameCache sc150 { get; set; }

        public GenerateCacheCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "GenerateCache",
            "Generates a new cache for use with ElDewrito 0.7",
            "GenerateCache",
            GenerateHelpText()
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        private static string GenerateHelpText()
        {
            var buffer = new StringBuilder();

            buffer.AppendLine("More specifically this command is designed to take existing data from within Halo Online MS23 and utilize it");
            buffer.AppendLine("to generate a completely fresh cache for use with ElDewrito 0.7 (Or any newer versions of ElDewrito). The");
            buffer.AppendLine("only real data used from MS23 is the explicit and chud shaders, as well as the render method definitions. All");
            buffer.AppendLine("other data is either ported from the specified caches or serialized at runtime using tag structures defined");
            buffer.AppendLine("in TagTool.");
            buffer.AppendLine();
            buffer.AppendLine("When the command is executed, it will request the input of multiple cache file directories.");
            buffer.AppendLine("These directories will contain the cache files for various different Halo builds, with these being:");
            buffer.AppendLine();
            buffer.AppendLine(" - Halo Online MS23 (1.106708 cert_ms23)");
            buffer.AppendLine(" - ElDewrito 0.6.1");
            buffer.AppendLine(" - Halo 3 Retail (11855.07.08.20.2317.halo3_ship)");
            buffer.AppendLine(" - Halo 3 Mythic Retail (12065.08.08.26.0819.halo3_ship)");
            buffer.AppendLine(" - Halo 3 ODST Retail (13895.09.04.27.2201.atlas_relea)");
            buffer.AppendLine();
            buffer.AppendLine("(Halo Online MS23 is automatically input, as it pulls the directory info from the current cache context)");
            buffer.AppendLine();
            buffer.AppendLine("For each build input (excluding MS23 and ElDewrito 0.6.1), ensure that ALL the cache files are");
            buffer.AppendLine("present in the specified directory as the command will open new cache instances for every map");
            buffer.AppendLine("in that specified build, so if any are missing it will cause it to fail.");
            buffer.AppendLine();
            buffer.AppendLine("For Halo Online MS23 and ElDewrito 0.6.1, ensure that all .dat files are present in the specified directory");
            buffer.AppendLine("The tag lists for each cache will be updated by tagtool at runtime after the directories are input.");
            buffer.AppendLine("These tag lists are built into tagtool, as the tag names referenced internally by the command are hardcoded.");
            buffer.AppendLine();
            buffer.AppendLine("Any other data required such as map info files, font packages or external resource data are stored within");
            buffer.AppendLine("tagtool itself. This data has been modified externally which is the only reason why this data is not ");
            buffer.AppendLine("being pulled from any of the specified caches, or modified using data from any of the specified caches");
            buffer.AppendLine();
            buffer.AppendLine("Assuming that no .map files are missing and each directory input contains valid cache files,");
            buffer.AppendLine("the resulting output after each directory has been input should look like:");
            buffer.AppendLine();
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your ElDewrito 0.6.1 cache files:");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your Halo 3 cache files:");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your Halo 3 Mythic cache files:");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your Halo 3 ODST cache files:");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the ouput directory for the generated cache:");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine();
            buffer.AppendLine("The last input will be for the output directory.");
            buffer.AppendLine("This is where the converted data will be saved during execution.");
            buffer.AppendLine();
            buffer.AppendLine("Minor Note: There will be some BLF errors which appear when the command retrieves the directory info for");
            buffer.AppendLine("Halo Online MS23 and when inputting the directory info for ElDewrito 0.6.1. This is mainly due to the fact");
            buffer.AppendLine("that Halo Online MS23 and ElDewrito 0.6.1 use different .map file formats from ElDewrito 0.7, and currently");
            buffer.AppendLine("the file reader in TagTool can only parse ElDewrito 0.7 .map files so it will display warnings about the");
            buffer.AppendLine("BLF files being invalid. So long as the accompanying tag data is valid, the command will function normally.");
            buffer.AppendLine();
            buffer.AppendLine("DISCLAIMER:");
            buffer.AppendLine("This command is highly, HIGHLY experimental. The resulting cache may exhibit behaviour anywhere from");
            buffer.AppendLine("minor bugs or graphical issues, crashes and general instability, to being completely non-functional");
            buffer.AppendLine();
            buffer.AppendLine("YOU HAVE BEEN WARNED!");
            buffer.AppendLine();
            buffer.AppendLine("Regards");
            buffer.AppendLine();
            buffer.AppendLine("MtnDewIt.");

            return buffer.ToString();
        }

        public override object Execute(List<string> args) 
        {
            Program._stopWatch.Start();

            getCacheFiles();
            moveFontPackage(outputDirectoryInfo.FullName);
            rebuildCache(outputDirectoryInfo.FullName);
            retargetCache(outputDirectoryInfo.FullName);
            GenerateRenderMethods();
            portTagData();
            modifyStrings();
            Globals();
            MultiplayerGlobals();
            ModGlobals();
            ForgeGlobals();
            ChudGlobals();
            GameVariantSettingsSetup();
            RasterizerGlobalsSetup();
            SurvivalGlobalsSetup();
            UserInterfaceGlobalsSetup();
            ShieldImpactSetup();
            SoundEffectTemplateSetup();
            SquadTemplatesSetup();
            applyUIPatches();
            applyHUDPatches();
            applyPlayerPatches();
            ContextStack.Pop();

            Program._stopWatch.Stop();

            var output = Program._stopWatch.ElapsedMilliseconds.FormatMilliseconds();
            var startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cache Generated Sucessfully. Time Taken: " + output);
            Console.ForegroundColor = startColor;

            return true;
        }

        public void getCacheFiles()
        {
            ho_cache = GameCache.Open($@"{CacheContext.Directory.FullName}\mainmenu.map");
            UpdateTagNames(ho_cache, ho_cache, UpdateHOTagsCommand.tagNameTable);

            eldewritoDirectoryInfo = getDirectoryInfo(eldewritoDirectoryInfo, "ElDewrito 0.6.1");

            ed_cache = GameCache.Open($@"{eldewritoDirectoryInfo.FullName}\mainmenu.map");
            UpdateTagNames(ho_cache, ed_cache, UpdateEDTagsCommand.tagNameTable);

            halo3DirectoryInfo = getDirectoryInfo(halo3DirectoryInfo, "Halo 3");

            h3_mainmenu = GameCache.Open($@"{halo3DirectoryInfo.FullName}\mainmenu.map");
            intro = GameCache.Open($@"{halo3DirectoryInfo.FullName}\005_intro.map");
            jungle = GameCache.Open($@"{halo3DirectoryInfo.FullName}\010_jungle.map");
            crows = GameCache.Open($@"{halo3DirectoryInfo.FullName}\020_base.map");
            outskirts = GameCache.Open($@"{halo3DirectoryInfo.FullName}\030_outskirts.map");
            voi = GameCache.Open($@"{halo3DirectoryInfo.FullName}\040_voi.map");
            floodvoi = GameCache.Open($@"{halo3DirectoryInfo.FullName}\050_floodvoi.map");
            waste = GameCache.Open($@"{halo3DirectoryInfo.FullName}\070_waste.map");
            citadel = GameCache.Open($@"{halo3DirectoryInfo.FullName}\100_citadel.map");
            highCharity = GameCache.Open($@"{halo3DirectoryInfo.FullName}\110_hc.map");
            halo = GameCache.Open($@"{halo3DirectoryInfo.FullName}\120_halo.map");
            epilogue = GameCache.Open($@"{halo3DirectoryInfo.FullName}\130_epilogue.map");

            halo3MythicDirectoryInfo = getDirectoryInfo(halo3MythicDirectoryInfo, "Halo 3 Mythic");

            mythic_mainmenu = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\mainmenu.map");
            armory = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\armory.map");
            bunkerworld = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\bunkerworld.map");
            chill = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\chill.map");
            chillout = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\chillout.map");
            construct = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\construct.map");
            cyberdyne = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\cyberdyne.map");
            deadlock = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\deadlock.map");
            descent = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\descent.map");
            docks = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\docks.map");
            fortress = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\fortress.map");
            ghosttown = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\ghosttown.map");
            guardian = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\guardian.map");
            isolation = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\isolation.map");
            lockout = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\lockout.map");
            midship = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\midship.map");
            riverworld = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\riverworld.map");
            salvation = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\salvation.map");
            sandbox = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\sandbox.map");
            shrine = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\shrine.map");
            sidewinder = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\sidewinder.map");
            snowbound = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\snowbound.map");
            spacecamp = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\spacecamp.map");
            warehouse = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\warehouse.map");
            zanzibar = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\zanzibar.map");

            halo3ODSTDirectoryInfo = getDirectoryInfo(halo3ODSTDirectoryInfo, "Halo 3 ODST");

            odst_mainmenu = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\mainmenu.map");
            h100 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\h100.map");
            c100 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\c100.map");
            c200 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\c200.map");
            l200 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\l200.map");
            l300 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\l300.map");
            sc100 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc100.map");
            sc110 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc110.map");
            sc120 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc120.map");
            sc130 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc130.map");
            sc140 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc140.map");
            sc150 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc150.map");

            outputDirectoryInfo = getOutputDirectory(outputDirectoryInfo);
        }

        public DirectoryInfo getDirectoryInfo(DirectoryInfo directoryInfo, String build)
        {
            Console.WriteLine("\nEnter the directory for your " + build + " cache files: ");
            var inputDirectory = Console.ReadLine();
            directoryInfo = new DirectoryInfo(inputDirectory);

            if (!directoryInfo.Exists)
            {
                new TagToolError(CommandError.CustomMessage, $"Directory not found: '{directoryInfo.FullName}'");
            }

            if (directoryInfo.Exists && !directoryInfo.GetFiles().Any(x => x.FullName.EndsWith(".map")))
            {
                new TagToolError(CommandError.CustomMessage, $"No .map files found in '{directoryInfo.FullName}'");
            }

            return directoryInfo;
        }

        public DirectoryInfo getOutputDirectory(DirectoryInfo directoryInfo)
        {
            Console.WriteLine("\nEnter the ouput directory for the generated cache: ");
            var inputDirectory = Console.ReadLine();
            directoryInfo = new DirectoryInfo(inputDirectory);

            if (!directoryInfo.Exists)
            {
                new TagToolWarning("This directory does not exist, or could not be found. Creating a new one...");
                directoryInfo.Create();
            }

            if (directoryInfo == eldewritoDirectoryInfo || directoryInfo == halo3DirectoryInfo || directoryInfo == halo3MythicDirectoryInfo || directoryInfo == halo3ODSTDirectoryInfo || directoryInfo == CacheContext.Directory)
            {
                new TagToolError(CommandError.CustomMessage, "Output directory cannot be the same as an input directory");
            }

            return directoryInfo;
        }

        public void UpdateTagNames(GameCache initialCache, GameCache targetCache, Dictionary<int, string> tagTable)
        {
            CacheContext = targetCache as GameCacheHaloOnline;

            using (var stream = CacheContext.OpenCacheRead())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tagTable.TryGetValue(tag.Index, out string name))
                    {
                        tag.Name = name;
                    }
                }
            }

            CacheContext.SaveTagNames();

            CacheContext = initialCache as GameCacheHaloOnline;
        }
    }
}