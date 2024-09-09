using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.MtnDewIt.JSON.Parsers;

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
        
            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\convertcache\tags.json");
            TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);
        
            foreach (var file in TagObjectList)
                TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");
        }

        public void UpdateMapData()
        {
            MapParser = new MapObjectParser(Cache, CacheContext, CacheStream);

            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\convertcache\maps.json");
            MapObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in MapObjectList)
                MapParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\maps\{file}");
        }
    }
}
