using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Porting;
using System.Text;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Security.AccessControl;
using TagTool.JSON;
using System.Linq;
using TagTool.Commands.Common;

namespace TagTool.Commands.GenerateDonkeyCache
{
    partial class GenerateDonkeyCacheCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }
        public Stream CacheStream { get; set; }
        public static DirectoryInfo SourceDirectoryInfo { get; set; }
        public static DirectoryInfo OutputDirectoryInfo { get; set; }

        public static DirectoryInfo haloOnlineDirectoryInfo { get; set; }
        public static DirectoryInfo halo3DirectoryInfo { get; set; }
        public static DirectoryInfo halo3MythicDirectoryInfo { get; set; }
        public static DirectoryInfo halo3ODSTDirectoryInfo { get; set; }

        public static GameCache haloOnlineCache { get; set; }
        public static PortingContext haloOnline { get; set; }

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

        public GenerateDonkeyCacheCommand(GameCache cache, CommandContextStack contextStack) : base
        (
            true,
            "GenerateDonkeyCache",
            "Generates a new cache for use with Managed Donkey",
            "GenerateDonkeyCache <Source Path> <Output Path>",
            GenerateHelpText()
        )
        {
            Cache = cache;
            ContextStack = contextStack;
        }

        private static string GenerateHelpText()
        {
            var buffer = new StringBuilder();

            // TODO: Add donkey specific help text

            return buffer.ToString();
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            SourceDirectoryInfo = new DirectoryInfo(args[0]);
            OutputDirectoryInfo = new DirectoryInfo(args[1]);

            if (!SourceDirectoryInfo.Exists)
                return new TagToolError(CommandError.CustomError, "Source data path does not exist, or could not be found");

            if (!OutputDirectoryInfo.Exists)
                return new TagToolError(CommandError.CustomError, "Output path does not exist, or could not be found");

            if (OutputDirectoryInfo.FullName == Cache.Directory.FullName)
                return new TagToolError(CommandError.CustomError, "Output path cannot be the same as the current working directory");

            GetCacheFiles();

            Program._stopWatch.Start();

            RebuildCache(OutputDirectoryInfo.FullName);
            RetargetCache(OutputDirectoryInfo.FullName);

            using (CacheStream = Cache.OpenCacheReadWrite())
            {
                PortTagData();
                UpdateTagData();
                UpdateMapData();
                //UpdateBlfData();
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
            haloOnlineDirectoryInfo = GetDirectoryInfo(haloOnlineDirectoryInfo, "Halo Online MS23");

            haloOnlineCache = GameCache.Open($@"{haloOnlineDirectoryInfo.FullName}\tags.dat");

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
        }

        public DirectoryInfo GetDirectoryInfo(DirectoryInfo directoryInfo, String build)
        {
            Console.WriteLine("\nEnter the directory for your " + build + " cache files: ");
            var inputDirectory = Console.ReadLine().Replace("\"", "");
            directoryInfo = new DirectoryInfo(inputDirectory);

            if (!directoryInfo.Exists)
            {
                new TagToolError(CommandError.CustomError, $"Directory not found: '{directoryInfo.FullName}'");
                throw new ArgumentException();
            }

            if (directoryInfo.Exists && !directoryInfo.GetFiles().Any(x => x.FullName.EndsWith(".map")))
            {
                new TagToolError(CommandError.CustomError, $"No .map files found in '{directoryInfo.FullName}'");
                throw new ArgumentException();
            }

            return directoryInfo;
        }
    }
}
