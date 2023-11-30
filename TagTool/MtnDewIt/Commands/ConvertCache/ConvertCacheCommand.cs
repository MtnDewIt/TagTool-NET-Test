using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;
using TagTool.Commands;
using TagTool.MtnDewIt.Porting;

namespace TagTool.MtnDewIt.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public static DirectoryInfo haloOnlineDirectoryInfo { get; set; }
        public static DirectoryInfo halo3DirectoryInfo { get; set; }
        public static DirectoryInfo halo3MythicDirectoryInfo { get; set; }
        public static DirectoryInfo halo3ODSTDirectoryInfo { get; set; }
        public static DirectoryInfo outputDirectoryInfo { get; set; }

        public GameCache haloOnlineCache { get; set; }
        public PortingContext haloOnline { get; set; }
        public static GameCache targetCache { get; set; }

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

        public ConvertCacheCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "ConvertCache",
            "Converts an ElDewrito 0.6 Cache to work with ElDewrito 0.7",
            "ConvertCache",
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

            buffer.AppendLine("More specifically this command is designed to take the existing cache used with ElDewito 0.6.1 and convert");
            buffer.AppendLine("the data within it so that it functions correctly within ElDewrito 0.7 (Or any newer versions of ElDewrito)");
            buffer.AppendLine();
            buffer.AppendLine("When the command is executed, it will request the input of multiple cache file directories.");
            buffer.AppendLine("These directories will contain the cache files for various different Halo builds, with these being: ");
            buffer.AppendLine();
            buffer.AppendLine(" - ElDewrito 0.6.1");
            buffer.AppendLine(" - Halo Online MS23 (1.106708 cert_ms23)");
            buffer.AppendLine(" - Halo 3 Retail (11855.07.08.20.2317.halo3_ship)");
            buffer.AppendLine(" - Halo 3 Mythic Retail (12065.08.08.26.0819.halo3_ship)");
            buffer.AppendLine(" - Halo 3 ODST Retail (13895.09.04.27.2201.atlas_relea)");
            buffer.AppendLine();
            buffer.AppendLine("(ElDewrito 0.6.1 is automatically input, as it pulls the directory info from the current cache context)");
            buffer.AppendLine();
            buffer.AppendLine("For each build input (excluding ElDewrito 0.6.1 and MS23), ensure that ALL the cache files are ");
            buffer.AppendLine("present in the specified directory as the command will open new cache instances for every map ");
            buffer.AppendLine("in that specified build, so if any are missing it will cause it to fail.");
            buffer.AppendLine();
            buffer.AppendLine("For ElDewrito 0.6.1 and Halo Online MS23, ensure that all .dat files are present in the specified directory ");
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
            buffer.AppendLine("Enter the directory for your Halo Online MS23 cache files: ");
            buffer.AppendLine("<insert_directory_here>");
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
            buffer.AppendLine("Enter the ouput directory for the generated cache: ");
            buffer.AppendLine("<insert_directory_here>");
            buffer.AppendLine();
            buffer.AppendLine();
            buffer.AppendLine("The last input will be for the output directory. ");
            buffer.AppendLine("This is where the converted data will be saved during execution.");
            buffer.AppendLine();
            buffer.AppendLine("Minor Note: There will be some BLF errors which appear when the command retrieves the directory info for ");
            buffer.AppendLine("ElDewrito 0.6.1 and when inputting the directory info for Halo Online MS23. This is mainly due to the fact ");
            buffer.AppendLine("that ElDewrito 0.6.1 and Halo Online MS23 use different .map file formats from ElDewrito 0.7, and currently ");
            buffer.AppendLine("the file reader in TagTool can only parse ElDewrito 0.7 .map files so it will display warnings about the ");
            buffer.AppendLine("BLF files being invalid. So long as the accompanying tag data is valid, the command will function normally.");
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
            MoveFontPackage(outputDirectoryInfo.FullName);
            RebuildCache(outputDirectoryInfo.FullName);
            RetargetCache(outputDirectoryInfo.FullName);
            UpdateShaderData();
            PortTagData();
            UpdateTagData();
            CommandRunner.Current.RunCommand($"updatemapfiles \"{Program.TagToolDirectory}\\Tools\\BaseCache\\MapInfo\"");
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
            targetCache = GameCache.Open($@"{CacheContext.Directory.FullName}\mainmenu.map");
            UpdateTagNames(targetCache, targetCache, UpdateEDTagsCommand.tagNameTable);

            haloOnlineDirectoryInfo = GetDirectoryInfo(haloOnlineDirectoryInfo, "Halo Online MS23");

            haloOnlineCache = GameCache.Open($@"{haloOnlineDirectoryInfo.FullName}\mainmenu.map");
            UpdateTagNames(targetCache, haloOnlineCache, UpdateHOTagsCommand.tagNameTable);

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

            if (directoryInfo == haloOnlineDirectoryInfo || directoryInfo == halo3DirectoryInfo || directoryInfo == halo3MythicDirectoryInfo || directoryInfo == halo3ODSTDirectoryInfo || directoryInfo == CacheContext.Directory)
            {
                new TagToolError(CommandError.CustomMessage, "Output directory cannot be the same as an input directory");
            }

            return directoryInfo;
        }

        public void UpdateTagNames(GameCache initialCache, GameCache targetCache, Dictionary<int, string> tagTable)
        {
            CacheContext = targetCache as GameCacheHaloOnline;

            foreach (var tag in CacheContext.TagCache.NonNull())
            {
                if (tagTable.TryGetValue(tag.Index, out string name))
                {
                    tag.Name = name;
                }
            }

            CacheContext.SaveTagNames();

            CacheContext = initialCache as GameCacheHaloOnline;
        }
    }
}