using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.HaloOnline;
using TagTool.Cache;
using TagTool.IO;

namespace TagTool.Commands.Editing
{
    class SaveMapChangesCommand : Command 
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
            var file = new FileInfo($@"{Cache.Directory.FullName}\{MapFile.Header.GetName()}.map");

            using (var fileStream = file.OpenWrite())
            using (var writer = new EndianWriter(fileStream)) 
            {
                var mapData = new MapFile
                {
                    Version = Cache.Version,
                    CachePlatform = Cache.Platform,
                    Header = MapFile.Header,
                    MapFileBlf = new Blf(Cache.Version, Cache.Platform)
                    {
                        Format = MapFile.Blf.Format,
                        ContentFlags = MapFile.Blf.ContentFlags,
                        AuthenticationType = MapFile.Blf.AuthenticationType,

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
                    },
                };

                mapData.Write(writer);
            }

            return true;
        }
    }
}
