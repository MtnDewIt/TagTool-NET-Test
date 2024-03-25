using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands
{
    class GenerateMapFilesCommand : Command
    {
        public GameCache Cache { get; set; }

        public GenerateMapFilesCommand(GameCache cache) : base
        (
            true,
            "GenerateMapFiles",
            "Generates new .map files containing valid scenario and map data.",
            "GenerateMapFiles <MapInfo Directory> [forceupdate]",
            "Generates new .map files containing valid scenario and map data."
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            bool forceUpdate = false;
            bool hasMapInfo = false;
            string mapInfo = "";

            if (args.Count >= 1) 
            {
                mapInfo = args[0];
                hasMapInfo = true;
            }
            if (args.Count == 2) 
            {
                if (args[1].ToLower() == "forceupdate") 
                {
                    forceUpdate = true;
                }
            }

            if (Cache is GameCacheHaloOnline)
            {
                if (Cache.Version == CacheVersion.HaloOnlineED)
                {
                    GenerateEDMap(mapInfo, forceUpdate, hasMapInfo);
                }

                if (Cache.Version == CacheVersion.HaloOnline106708)
                {
                    //if (/*insert function to which determines if its a 0.6 cache*/)
                    //{
                    //    GenerateLegacyMap(mapInfo, forceUpdate, hasMapInfo);
                    //}
                    //else 
                    //{
                    //    GenerateMS23Map(mapInfo, forceUpdate, hasMapInfo);
                    //}
                }

                if (Cache.Version >= CacheVersion.HaloOnline235640)
                {
                    GenerateAnvilMap(mapInfo, forceUpdate, hasMapInfo);
                }
            }
            else if (Cache is GameCacheModPackage modPackCache)
            {
                GenerateModPackageMap(modPackCache, mapInfo, hasMapInfo);
            }

            return true;
        }

        public void GenerateModPackageMap(GameCacheModPackage modPackCache, string mapInfo, bool hasMapInfo)
        {
            // For 0.7 mod packages
            // Might have issues when generating maps for non 0.7 mod packages
        }

        public void GenerateEDMap(string mapInfo, bool forceUpdate ,bool hasMapInfo)
        {
            // For 0.7 caches
        }

        public void GenerateLegacyMap(string mapInfo, bool forceUpdate, bool hasMapInfo)
        {
            // For 0.6 caches
        }

        public void GenerateMS23Map(string mapInfo, bool forceUpdate, bool hasMapInfo)
        {
            // For MS23 caches and any projects which use MS23 as a base (Looking at ManagedDonkey and Halal Station)
        }

        public void GenerateAnvilMap(string mapInfo, bool forceUpdate, bool hasMapInfo)
        {
            // For any newer Halo Online builds (Potential Anvil Station Support???)
        }
    }
}