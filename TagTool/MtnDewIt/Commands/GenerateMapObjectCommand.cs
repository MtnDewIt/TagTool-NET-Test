using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.MtnDewIt.JSON;
using TagTool.MtnDewIt.JSON.Handlers;

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

            "GenerateMapObject <Map_Path>",
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
            var mapData = new MapFileData();

            // Wrapping the whole thing in a using statement probably isn't the best idea
            using (var stream = file.OpenRead()) 
            {
                var reader = new EndianReader(stream);

                mapData.ReadData(reader);

                var mapObject = new MapObject() 
                {
                    MapName = file.Name,
                    MapVersion = mapData.Version,
                    CacheFileHeaderData = mapData.Header,
                    BlfData = mapData.MapFileBlf,
                };

                var jsonData = handler.Serialize(mapObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{file.Name}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{file.Name}.json"), jsonData);
            }

            return true;
        }
    }
}