using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.MtnDewIt.JSON.Objects;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands 
{
    public class GenerateMapObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private string ExportPath = $@"maps";

        public GenerateMapObjectCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            false,
            "GenerateMapObject",
            "Generates a JSON map object file based on the specified map file",

            "GenerateMapObject <Map_Path> [Suffix]",
            "Generates a JSON map object file based on the specified map file"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            var handler = new MapObjectHandler(Cache, CacheContext);

            var file = new FileInfo(args[0]);
            var suffix = args.Count > 1 ? args[1] : null;
            var mapData = new MapFileData();

            var mapName = Path.GetFileNameWithoutExtension(file.Name);

            var fileName = suffix != null ? $"{mapName}_{suffix}" : mapName;

            // Wrapping the whole thing in a using statement probably isn't the best idea
            using (var stream = file.OpenRead()) 
            {
                var reader = new EndianReader(stream);

                mapData.ReadData(reader);

                var mapObject = new MapObject() 
                {
                    MapName = mapName,
                    MapVersion = mapData.Version,
                    CacheFileHeaderData = mapData.Header,
                    BlfData = mapData.MapFileBlf,
                };

                var headerData = mapData.Header as CacheFileHeaderDataHaloOnline;

                headerData.ScenarioTagIndex = 0;

                var jsonData = handler.Serialize(mapObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{fileName}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{fileName}.json"), jsonData);
            }

            return true;
        }
    }
}