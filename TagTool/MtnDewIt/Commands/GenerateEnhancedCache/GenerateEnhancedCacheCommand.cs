using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.MtnDewIt.Porting;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache
{
    partial class GenerateEnhancedCacheCommand : Command 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }
        public Stream CacheStream { get; set; }

        public static DirectoryInfo halo3DirectoryInfo { get; set; }
        public static DirectoryInfo halo3MythicDirectoryInfo { get; set; }
        public static DirectoryInfo halo3ODSTDirectoryInfo { get; set; }
        public static DirectoryInfo halo3MCCDirectoryInfo { get; set; }
        public static DirectoryInfo outputDirectoryInfo { get; set; }

        public GameCache h3MainMenuCache { get; set; }
        public PortingContext h3MainMenu { get; set; }
        public GameCache introCache { get; set; }
        public PortingContext intro { get; set; }
        public GameCache jungleCache { get; set; }
        public PortingContext jungle { get; set; }
        public GameCache crowsCache { get; set; }
        public PortingContext crows { get; set; }
        public GameCache outskirtsCache { get; set; }
        public PortingContext outskirts { get; set; }
        public GameCache voiCache { get; set; }
        public PortingContext voi { get; set; }
        public GameCache floodvoiCache { get; set; }
        public PortingContext floodvoi { get; set; }
        public GameCache wasteCache { get; set; }
        public PortingContext waste { get; set; }
        public GameCache citadelCache { get; set; }
        public PortingContext citadel { get; set; }
        public GameCache highCharityCache { get; set; }
        public PortingContext highCharity { get; set; }
        public GameCache haloCache { get; set; }
        public PortingContext halo { get; set; }
        public GameCache epilogueCache { get; set; }
        public PortingContext epilogue { get; set; }

        public GameCache mythicMainMenuCache { get; set; }
        public PortingContext mythicMainMenu { get; set; }
        public GameCache armoryCache { get; set; }
        public PortingContext armory { get; set; }
        public GameCache bunkerworldCache { get; set; }
        public PortingContext bunkerworld { get; set; }
        public GameCache chillCache { get; set; }
        public PortingContext chill { get; set; }
        public GameCache chilloutCache { get; set; }
        public PortingContext chillout { get; set; }
        public GameCache constructCache { get; set; }
        public PortingContext construct { get; set; }
        public GameCache cyberdyneCache { get; set; }
        public PortingContext cyberdyne { get; set; }
        public GameCache deadlockCache { get; set; }
        public PortingContext deadlock { get; set; }
        public GameCache descentCache { get; set; }
        public PortingContext descent { get; set; }
        public GameCache docksCache { get; set; }
        public PortingContext docks { get; set; }
        public GameCache fortressCache { get; set; }
        public PortingContext fortress { get; set; }
        public GameCache ghosttownCache { get; set; }
        public PortingContext ghosttown { get; set; }
        public GameCache guardianCache { get; set; }
        public PortingContext guardian { get; set; }
        public GameCache isolationCache { get; set; }
        public PortingContext isolation { get; set; }
        public GameCache lockoutCache { get; set; }
        public PortingContext lockout { get; set; }
        public GameCache midshipCache { get; set; }
        public PortingContext midship { get; set; }
        public GameCache riverworldCache { get; set; }
        public PortingContext riverworld { get; set; }
        public GameCache salvationCache { get; set; }
        public PortingContext salvation { get; set; }
        public GameCache sandboxCache { get; set; }
        public PortingContext sandbox { get; set; }
        public GameCache shrineCache { get; set; }
        public PortingContext shrine { get; set; }
        public GameCache sidewinderCache { get; set; }
        public PortingContext sidewinder { get; set; }
        public GameCache snowboundCache { get; set; }
        public PortingContext snowbound { get; set; }
        public GameCache spacecampCache { get; set; }
        public PortingContext spacecamp { get; set; }
        public GameCache warehouseCache { get; set; }
        public PortingContext warehouse { get; set; }
        public GameCache zanzibarCache { get; set; }
        public PortingContext zanzibar { get; set; }

        public GameCache odstMainMenuCache { get; set; }
        public PortingContext odstMainMenu { get; set; }
        public GameCache h100Cache { get; set; }
        public PortingContext h100 { get; set; }
        public GameCache c100Cache { get; set; }
        public PortingContext c100 { get; set; }
        public GameCache c200Cache { get; set; }
        public PortingContext c200 { get; set; }
        public GameCache l200Cache { get; set; }
        public PortingContext l200 { get; set; }
        public GameCache l300Cache { get; set; }
        public PortingContext l300 { get; set; }
        public GameCache sc100Cache { get; set; }
        public PortingContext sc100 { get; set; }
        public GameCache sc110Cache { get; set; }
        public PortingContext sc110 { get; set; }
        public GameCache sc120Cache { get; set; }
        public PortingContext sc120 { get; set; }
        public GameCache sc130Cache { get; set; }
        public PortingContext sc130 { get; set; }
        public GameCache sc140Cache { get; set; }
        public PortingContext sc140 { get; set; }
        public GameCache sc150Cache { get; set; }
        public PortingContext sc150 { get; set; }

        public GameCache s3d_waterfallCache { get; set; }
        public PortingContext s3d_waterfall { get; set; }
        public GameCache s3d_sky_bridgenewCache { get; set; }
        public PortingContext s3d_sky_bridgenew { get; set; }
        public GameCache s3d_lockoutCache { get; set; }
        public PortingContext s3d_lockout { get; set; }
        public GameCache s3d_powerhouseCache { get; set; }
        public PortingContext s3d_powerhouse { get; set; }

        public GenerateEnhancedCacheCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "GenerateEnhancedCache",
            "Adds extra content to an existing ElDewrito 0.6 cache",
            "GenerateEnhancedCache",
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

            buffer.AppendLine("More specifically this command is designed to take the existing cache used with ElDewito 0.6.1 and add extra");
            buffer.AppendLine("content, such as extra maps, and some minor patches to existing tag data.");
            buffer.AppendLine();
            buffer.AppendLine("When the command is executed, it will request the input of multiple cache file directories.");
            buffer.AppendLine("These directories will contain the cache files for various different Halo builds, with these being: ");
            buffer.AppendLine();
            buffer.AppendLine(" - ElDewrito 0.6.1");
            buffer.AppendLine(" - Halo 3 Retail (11855.07.08.20.2317.halo3_ship)");
            buffer.AppendLine(" - Halo 3 Mythic Retail (12065.08.08.26.0819.halo3_ship)");
            buffer.AppendLine(" - Halo 3 ODST Retail (13895.09.04.27.2201.atlas_relea)");
            buffer.AppendLine(" - Halo 3 Editing Kit Maps (Peferably compiled from the most recent version)");
            buffer.AppendLine();
            buffer.AppendLine("(ElDewrito 0.6.1 is automatically input, as it pulls the directory info from the current cache context)");
            buffer.AppendLine();
            buffer.AppendLine("For each build input (excluding ElDewrito 0.6.1), ensure that ALL the cache files are ");
            buffer.AppendLine("present in the specified directory as the command will open new cache instances for every map ");
            buffer.AppendLine("in that specified build, so if any are missing it will cause it to fail.");
            buffer.AppendLine();
            buffer.AppendLine("For ElDewrito 0.6.1, ensure that all .dat files are present in the specified directory ");
            buffer.AppendLine("The tag lists for each cache will be updated by tagtool at runtime after the directories are input. ");
            buffer.AppendLine("These tag lists are built into tagtool, as the tag names referenced internally by the command are hardcoded.");
            buffer.AppendLine();
            buffer.AppendLine("Any other data required such as map info files, font packages or external resource data are stored within ");
            buffer.AppendLine("tagtool itself. This data has been modified externally which is the only reason why this data is not ");
            buffer.AppendLine("being pulled from any of the specified caches, or modified using data from any of the specified caches");
            buffer.AppendLine();
            buffer.AppendLine("Assuming that no .map files are missing and each directory input contains valid cache files, ");
            buffer.AppendLine("the resulting output after each directory has been input should look like: ");
            buffer.AppendLine();
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your Halo 3 cache files: ");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your Halo 3 Mythic cache files: ");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your Halo 3 ODST cache files: ");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the directory for your Halo 3 MCC cache files: ");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine("Enter the ouput directory for the generated cache: ");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine();
            buffer.AppendLine("The last input will be for the output directory. ");
            buffer.AppendLine("This is where the converted data will be saved during execution.");
            buffer.AppendLine();
            buffer.AppendLine("DISCLAIMER: ");
            buffer.AppendLine("This command is highly, HIGHLY experimental. The resulting cache may exhibit behaviour anywhere from ");
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
            GetCacheFiles();

            Program._stopWatch.Start();

            CopyCacheFiles(outputDirectoryInfo.FullName);
            RetargetCache(outputDirectoryInfo.FullName);
            UpdateTagNames();

            using (CacheStream = Cache.OpenCacheReadWrite()) 
            {
                //UpdateShaderData();
                PortTagData();
                UpdateTagData();
                UpdateMapFiles();
            }
            
            ContextStack.Pop();

            Program._stopWatch.Stop();

            var output = Program._stopWatch.ElapsedMilliseconds.FormatMilliseconds();
            var startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cache Generated Sucessfully. Time Taken: " + output);
            Console.ForegroundColor = startColor;

            return true;
        }

        public void GetCacheFiles()
        {
            halo3DirectoryInfo = GetDirectoryInfo(halo3DirectoryInfo, "Halo 3");

            h3MainMenuCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\mainmenu.map");
            introCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\005_intro.map");
            jungleCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\010_jungle.map");
            crowsCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\020_base.map");
            outskirtsCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\030_outskirts.map");
            voiCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\040_voi.map");
            floodvoiCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\050_floodvoi.map");
            wasteCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\070_waste.map");
            citadelCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\100_citadel.map");
            highCharityCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\110_hc.map");
            haloCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\120_halo.map");
            epilogueCache = GameCache.Open($@"{halo3DirectoryInfo.FullName}\130_epilogue.map");

            halo3MythicDirectoryInfo = GetDirectoryInfo(halo3MythicDirectoryInfo, "Halo 3 Mythic");

            mythicMainMenuCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\mainmenu.map");
            armoryCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\armory.map");
            bunkerworldCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\bunkerworld.map");
            chillCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\chill.map");
            chilloutCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\chillout.map");
            constructCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\construct.map");
            cyberdyneCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\cyberdyne.map");
            deadlockCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\deadlock.map");
            descentCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\descent.map");
            docksCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\docks.map");
            fortressCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\fortress.map");
            ghosttownCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\ghosttown.map");
            guardianCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\guardian.map");
            isolationCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\isolation.map");
            lockoutCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\lockout.map");
            midshipCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\midship.map");
            riverworldCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\riverworld.map");
            salvationCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\salvation.map");
            sandboxCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\sandbox.map");
            shrineCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\shrine.map");
            sidewinderCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\sidewinder.map");
            snowboundCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\snowbound.map");
            spacecampCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\spacecamp.map");
            warehouseCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\warehouse.map");
            zanzibarCache = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\zanzibar.map");

            halo3ODSTDirectoryInfo = GetDirectoryInfo(halo3ODSTDirectoryInfo, "Halo 3 ODST");

            odstMainMenuCache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\mainmenu.map");
            h100Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\h100.map");
            c100Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\c100.map");
            c200Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\c200.map");
            l200Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\l200.map");
            l300Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\l300.map");
            sc100Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc100.map");
            sc110Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc110.map");
            sc120Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc120.map");
            sc130Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc130.map");
            sc140Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc140.map");
            sc150Cache = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\sc150.map");

            halo3MCCDirectoryInfo = GetDirectoryInfo(halo3MCCDirectoryInfo, "Halo 3 MCC");
            
            s3d_waterfallCache = GameCache.Open($@"{halo3MCCDirectoryInfo.FullName}\s3d_waterfall.map");
            s3d_sky_bridgenewCache = GameCache.Open($@"{halo3MCCDirectoryInfo.FullName}\s3d_sky_bridgenew.map");
            s3d_lockoutCache = GameCache.Open($@"{halo3MCCDirectoryInfo.FullName}\s3d_lockout.map");
            s3d_powerhouseCache = GameCache.Open($@"{halo3MCCDirectoryInfo.FullName}\s3d_powerhouse.map");

            outputDirectoryInfo = GetOutputDirectory(outputDirectoryInfo);
        }

        public DirectoryInfo GetDirectoryInfo(DirectoryInfo directoryInfo, String build)
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

        public DirectoryInfo GetOutputDirectory(DirectoryInfo directoryInfo)
        {
            Console.WriteLine("\nEnter the ouput directory for the generated cache: ");
            var inputDirectory = Console.ReadLine();
            directoryInfo = new DirectoryInfo(inputDirectory);

            if (!directoryInfo.Exists)
            {
                new TagToolWarning("This directory does not exist, or could not be found. Creating a new one...");
                directoryInfo.Create();
            }

            if (directoryInfo == halo3DirectoryInfo || directoryInfo == halo3MythicDirectoryInfo || directoryInfo == halo3ODSTDirectoryInfo || directoryInfo == halo3MCCDirectoryInfo || directoryInfo == CacheContext.Directory)
            {
                new TagToolError(CommandError.CustomMessage, "Output directory cannot be the same as an input directory");
            }

            return directoryInfo;
        }

        public void UpdateTagNames() 
        {
            foreach (var tag in CacheContext.TagCache.NonNull())
            {
                if (UpdateEDTagsCommand.tagNameTable.TryGetValue(tag.Index, out string name))
                {
                    tag.Name = name;
                }
            }

            CacheContext.SaveTagNames();
        }

        public void CopyCacheFiles(string outputDirectory) 
        {
            string[] remove = { "map", "dat", "csv" };

            var outputInfo = new DirectoryInfo(outputDirectory);
            Directory.CreateDirectory($@"{outputDirectory}\fonts");

            if (outputInfo.GetFiles().Any(x => x.FullName.EndsWith(".map") || x.FullName.EndsWith(".dat") || x.FullName.EndsWith(".csv")))
            {
                new TagToolWarning($@"Cache Detected in Specified Directory! Replacing Anyway.");

                foreach (string fileType in remove)
                {
                    FileInfo[] files = outputInfo.GetFiles("*." + fileType);

                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                }
            }

            if (!File.Exists($@"{outputDirectory}\fonts\font_package.bin"))
            {
                File.Copy($@"{Cache.Directory.FullName}\fonts\font_package.bin", $@"{outputDirectory}\fonts\font_package.bin");
            }
            else
            {
                new TagToolWarning($@"Font Package Detected in Specified Directory! Replacing Anyway.");
                File.Copy($@"{Cache.Directory.FullName}\fonts\font_package.bin", $@"{outputDirectory}\fonts\font_package.bin", true);
            }

            FileInfo[] cacheFiles = Cache.Directory.GetFiles("*.dat");

            foreach (FileInfo file in cacheFiles)
            {
                file.CopyTo($@"{outputDirectory}\{file.Name}");
            }
        }

        public void RetargetCache(string cache)
        {
            var newFileInfo = new FileInfo($@"{cache}\tags.dat");
            Cache = GameCache.Open(newFileInfo);
            CacheContext = Cache as GameCacheHaloOnline;
            ContextStack.Push(TagCacheContextFactory.Create(ContextStack, Cache));
        }
    }
}