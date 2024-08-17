using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.IO;

namespace TagTool.MtnDewIt.JSON
{
    public class BlfObjectParser 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private Stream CacheStream;
        private BlfObjectHandler Handler;

        public BlfObjectParser(GameCache cache, GameCacheHaloOnline cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            Handler = new BlfObjectHandler(Cache, CacheContext);
        }

        public void ParseFile(string filePath)
        {
            var jsonData = File.ReadAllText($@"{filePath}.json");
            var blfObject = Handler.Deserialize(jsonData);

            var blfFile = new FileInfo($@"{Cache.Directory.FullName}\{blfObject.FileName}.{blfObject.FileType}");

            using (var stream = blfFile.Create())
            using (var writer = new EndianWriter(stream)) 
            {
                blfObject.BlfData.WriteData(writer);
            }
        }
    }
}
