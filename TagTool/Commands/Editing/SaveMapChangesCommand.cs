using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.Eldorado;
using TagTool.Cache;
using TagTool.Cache.Eldorado;
using TagTool.IO;

namespace TagTool.Commands.Editing
{
    public class SaveMapChangesCommand : Command 
    {
        private GameCache Cache { get; }
        private EldoradoMapFile MapFile { get; }

        public SaveMapChangesCommand(GameCache cache, EldoradoMapFile mapFile)
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
                MapVersion = CacheFileVersion.Eldorado,
                Version = Cache.Version,
                Platform = Cache.Platform,
                Header = MapFile.Header,
            };

            if (Cache.Version == CacheVersion.EldoradoED)
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

            if (Cache is GameCacheModPackage)
            {
                var modCache = Cache as GameCacheModPackage;

                for (int i = 0; i < modCache.BaseModPackage.MapFileStreams.Count; i++) 
                {
                    var baseMapData = new MapFile();

                    var stream = modCache.BaseModPackage.MapFileStreams[i];
                    var reader = new EndianReader(stream);
                    baseMapData.Read(reader);
                    stream.Position = 0;

                    if (mapData.Header.GetName() == baseMapData.Header.GetName()) 
                    {
                        var writer = new EndianWriter(stream);
                        mapData.Write(writer);
                        stream.Position = 0;
                    }
                }
            }
            else 
            {
                var file = new FileInfo($@"{Cache.Directory.FullName}\{MapFile.Header.GetName()}.map");

                using (var fileStream = file.OpenWrite())
                using (var writer = new EndianWriter(fileStream))
                {
                    mapData.Write(writer);
                }
            }

            return true;
        }
    }
}
