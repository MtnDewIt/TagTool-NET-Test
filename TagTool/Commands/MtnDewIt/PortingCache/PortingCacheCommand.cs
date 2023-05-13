using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags 
{
    partial class PortingCacheCommand : Command 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public string cacheType { get; set; }

        public static DirectoryInfo halo3DirectoryInfo { get; set; }
        public static DirectoryInfo halo3MythicDirectoryInfo { get; set; }
        public static DirectoryInfo halo3ODSTDirectoryInfo { get; set; }
        public static DirectoryInfo outputDirectoryInfo { get; set; }

        public GameCache h3_mainmenu { get; set; }
        public GameCache crows {get; set; }
        public GameCache citadel { get; set; }
        public GameCache halo { get; set; }
        public GameCache h3_mythic_mainmenu { get; set; }
        public GameCache sandbox { get; set; }
        public GameCache h3_odst_mainmenu { get; set; }
        public GameCache h100 { get; set; }

        public PortingCacheCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "PortingCache",
            "<Proper Documentation Coming Soon>",
            "PortingCache",
            "<Proper Documentation Coming Soon>"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args) 
        {
            Console.WriteLine("\nEnter which cache type you would like to generate: ");
            var portingCacheType = Console.ReadLine().ToLower();

            switch (portingCacheType)
            {
                case "halo3":
                    cacheType = "Halo 3";
                    getCacheFiles();
                    generateCache();
                    break;

                case "halo3mythic":
                    cacheType = "Halo 3 Mythic";
                    getCacheFiles();
                    generateCache();
                    break;

                case "haloonline":
                    cacheType = "Halo Online";
                    //Implement at some point? (0.6 main menu and HO assets (maybe add ms23 main menu as an option at some point?))
                    break;

                case "mcc":
                    cacheType = "MCC";
                    //Test existing code with MCC cache files (Add support for modded MCC main menus?)
                    break;
            }

            return true;
        }

        public void getCacheFiles()
        {
            halo3DirectoryInfo = getDirectoryInfo(halo3DirectoryInfo, "Halo 3");

            h3_mainmenu = GameCache.Open($@"{halo3DirectoryInfo.FullName}\mainmenu.map");
            crows = GameCache.Open($@"{halo3DirectoryInfo.FullName}\020_base.map");
            citadel = GameCache.Open($@"{halo3DirectoryInfo.FullName}\100_citadel.map");
            halo = GameCache.Open($@"{halo3DirectoryInfo.FullName}\120_halo.map");

            halo3MythicDirectoryInfo = getDirectoryInfo(halo3MythicDirectoryInfo, "Halo 3 Mythic");

            h3_mythic_mainmenu = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\mainmenu.map");
            sandbox = GameCache.Open($@"{halo3MythicDirectoryInfo.FullName}\sandbox.map");

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

        public void generateCache()
        {
            moveFontPackage();
            CommandRunner.Current.RunCommand($@"nameunnamedtags"); //Maybe move into a method, instead of a command?
            rebuildCache(outputDirectoryInfo.FullName);
            retargetCache();
            GenerateRenderMethods();
            portTagData();
            Globals();
            MultiplayerGlobals();
            ModGlobals();
            ForgeGlobals(); // Unused for the time being
            ChudGlobals();
            RasterizerGlobalsSetup();
            SurvivalGlobalsSetup();
            ShieldImpactSetup();
            SoundEffectTemplateSetup();
            SquadTemplatesSetup();
            
            // Will add functions for modifying the UI once the UI is functional
            
            applyHUDPatches();
            applyPlayerPatches();
            ContextStack.Pop();
        }
    }
}