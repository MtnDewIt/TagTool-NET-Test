using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.HaloOnline;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.IO;

namespace TagTool.Commands.Editing
{
    public class SaveMapChangesCommand : Command 
    {
        private GameCache Cache { get; }
        private HaloOnlineMapFile MapFile { get; }

        public SaveMapChangesCommand(GameCache cache, HaloOnlineMapFile mapFile)
            : base(true,
                  "SaveMapChanges",
                  $"Saves changes made to the current {mapFile.Header.GetName()}.map file instance.",
                  "SaveMapChanges",
                  $"Saves changes made to the current {mapFile.Header.GetName()}.map file instance.")
        {
            Cache = cache;
            MapFile = mapFile;
        }

        public override object Execute(List<string> args)
        {
            var mapData = new MapFile
            {
                MapVersion = CacheFileVersion.HaloOnline,
                Version = Cache.Version,
                Platform = Cache.Platform,
                Header = MapFile.Header,
            };

            if (Cache.Version == CacheVersion.HaloOnlineED)
            {
                mapData.MapFileBlf = new Blf(Cache.Version, Cache.Platform)
                {
                    Format = MapFile.Blf.Format,
                    ContentFlags = MapFile.Blf.ContentFlags,

                    StartOfFile = MapFile.Blf.StartOfFile,
                    EndOfFileCRC = MapFile.Blf.EndOfFileCRC,
                    EndOfFileRSA = MapFile.Blf.EndOfFileRSA,
                    EndOfFileSHA1 = MapFile.Blf.EndOfFileSHA1,
                    EndOfFile = MapFile.Blf.EndOfFile,
                    Author = MapFile.Blf.Author,
                    Campaign = MapFile.Blf.Campaign,
                    Scenario = MapFile.Blf.Scenario,
                    ModReference = MapFile.Blf.ModReference,
                    MapVariantTagNames = MapFile.Blf.MapVariantTagNames,
                    MapVariant = MapFile.Blf.MapVariant,
                    GameVariant = MapFile.Blf.GameVariant,
                    ContentHeader = MapFile.Blf.ContentHeader,
                    MapImage = MapFile.Blf.MapImage,
                    Buffer = MapFile.Blf.Buffer,
                };
            }
            else 
            {
                mapData.Reports = new CacheFileReports(Cache.Version)
                {
                    Reports = MapFile.Reports.Reports,
                };
            }

            if (Cache is GameCacheModPackage modCache)
            {
                modCache.MapFiles.Add(mapData);
            }
            else if (Cache is GameCacheHaloOnline hoCache)
            {
                hoCache.MapFiles.Add(mapData);
            }

            return true;
        }
    }
}
