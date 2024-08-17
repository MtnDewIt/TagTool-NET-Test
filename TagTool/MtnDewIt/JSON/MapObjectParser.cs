using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.JSON
{
    public class MapObjectParser 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private Stream CacheStream;
        private MapObjectHandler Handler;

        public MapObjectParser(GameCache cache, GameCacheHaloOnline cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            Handler = new MapObjectHandler(Cache, CacheContext);
        }

        public void ParseFile(string filePath) 
        {
            var jsonData = File.ReadAllText($@"{filePath}.json");
            var mapObject = Handler.Deserialize(jsonData);

            var mapFile = new FileInfo($@"{Cache.Directory.FullName}\{mapObject.MapName}.map");

            using (var stream = mapFile.Create())
            using (var writer = new EndianWriter(stream))
            {
                var mapData = new MapFileData()
                {
                    Version = mapObject.MapVersion,
                    Header = mapObject.CacheFileHeaderData,
                    MapFileBlf = mapObject.BlfData,
                };

                mapData.WriteData(writer);
            }
        }
    }
}
