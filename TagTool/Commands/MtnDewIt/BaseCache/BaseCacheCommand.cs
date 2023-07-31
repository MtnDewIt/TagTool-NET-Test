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

        public static DirectoryInfo halo3DirectoryInfo { get; set; }
        public static DirectoryInfo halo3MythicDirectoryInfo { get; set; }
        public static DirectoryInfo halo3ODSTDirectoryInfo { get; set; }
        public static DirectoryInfo outputDirectoryInfo { get; set; }

        public GameCache ho_cache { get; set; }
        public GameCache h3_mainmenu { get; set; }
        public GameCache voi { get; set; }
        public GameCache citadel { get; set; }
        public GameCache halo { get; set; }
        public GameCache sandbox { get; set; }
        public GameCache shrine { get; set; }
        public GameCache h100 { get; set; }

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

        // TODO: Add Function For Parsing Current Cache (Stops Command From Using 0.6 cache, instead of MS23)
        public override object Execute(List<string> args) 
        {
            CommandRunner.Current.RunCommand($@"nameunnamedhaloonlinetags"); //Maybe move into a method, instead of a command?
            getCacheFiles();
            moveFontPackage();
            rebuildCache(outputDirectoryInfo.FullName);
            retargetCache();
            GenerateRenderMethods();
            portTagData();
            modifyStrings();
            Globals();
            MultiplayerGlobals();
            ModGlobals();
            //ForgeGlobals(); // Unused for the time being
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

            return true;
        }

        public void getCacheFiles()
        {
            ho_cache = GameCache.Open($@"{CacheContext.Directory.FullName}\mainmenu.map");

            halo3DirectoryInfo = getDirectoryInfo(halo3DirectoryInfo, "Halo 3");

            h3_mainmenu = GameCache.Open($@"{halo3DirectoryInfo.FullName}\mainmenu.map");
            voi = GameCache.Open($@"{halo3DirectoryInfo.FullName}\040_voi.map");
            citadel = GameCache.Open($@"{halo3DirectoryInfo.FullName}\100_citadel.map");
            halo = GameCache.Open($@"{halo3DirectoryInfo.FullName}\120_halo.map");

            halo3MythicDirectoryInfo = getDirectoryInfo(halo3MythicDirectoryInfo, "Halo 3 Mythic");

            sandbox = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\sandbox.map");
            shrine = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\shrine.map");

            halo3ODSTDirectoryInfo = getDirectoryInfo(halo3ODSTDirectoryInfo, "Halo 3 ODST");

            h100 = GameCache.Open($@"{halo3ODSTDirectoryInfo.FullName}\h100.map");

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