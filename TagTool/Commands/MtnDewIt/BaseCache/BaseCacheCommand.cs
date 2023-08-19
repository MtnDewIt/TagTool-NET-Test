using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheCommand : Command 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public static DirectoryInfo eldewritoDirectoryInfo { get; set; }
        public static DirectoryInfo halo3DirectoryInfo { get; set; }
        public static DirectoryInfo halo3MythicDirectoryInfo { get; set; }
        public static DirectoryInfo halo3ODSTDirectoryInfo { get; set; }
        public static DirectoryInfo outputDirectoryInfo { get; set; }

        public GameCache ho_cache { get; set; }
        public GameCache ed_cache { get; set; }

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

        public BaseCacheCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "BaseCache",
            "<Proper Documentation Coming Soon>",
            "BaseCache",
            "<Proper Documentation Coming Soon>"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args) 
        {
            Program._stopWatch.Start();

            CommandRunner.Current.RunCommand($@"nameunnamedhaloonlinetags"); //Maybe move into a method, instead of a command?
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

            // TODO: Have it name ED tags automatically (Shit breaks if tag lists aren't up to date)
            eldewritoDirectoryInfo = getDirectoryInfo(eldewritoDirectoryInfo, "ElDewrito 0.6.1");

            ed_cache = GameCache.Open($@"{eldewritoDirectoryInfo.FullName}\mainmenu.map");

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

            return directoryInfo;
        }
    }
}