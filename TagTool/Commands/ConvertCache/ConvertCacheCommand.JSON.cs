using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.JSON.Parsers;

namespace TagTool.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command 
    {
        private TagObjectParser TagParser;
        private MapObjectParser MapParser;

        private List<string> TagObjectList;
        private List<string> MapObjectList;

        public void UpdateTagData()
        {
            TagParser = new TagObjectParser(Cache, CacheContext, CacheStream);
        
            var jsonData = File.ReadAllText($@"{JSONFileTree.JSONCommandPath}convertcache\tags.json");
            TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);
        
            foreach (var file in TagObjectList)
                TagParser.ParseFile(file);
        }

        public void UpdateMapData()
        {
            MapParser = new MapObjectParser(Cache, CacheContext, CacheStream);

            var jsonData = File.ReadAllText($@"{JSONFileTree.JSONCommandPath}convertcache\maps.json");
            MapObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in MapObjectList)
                MapParser.ParseFile(file);
        }
    }
}
