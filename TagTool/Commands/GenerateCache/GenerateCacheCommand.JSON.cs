using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.JSON.Parsers;

namespace TagTool.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command 
    {
        private TagObjectParser TagParser;
        private MapObjectParser MapParser;
        private BlfObjectParser BlfParser;

        private List<string> TagObjectList;
        private List<string> MapObjectList;
        private List<string> BlfObjectList;

        private Dictionary<GeneratedCacheType, string> CacheTypePath = new Dictionary<GeneratedCacheType, string>
        {
            { GeneratedCacheType.Halo3, $@"{JSONFileTree.JSONCommandPath}generatecache\tags_h3.json" },
            { GeneratedCacheType.Halo3Mythic, $@"{JSONFileTree.JSONCommandPath}generatecache\tags_mythic.json" },
            { GeneratedCacheType.Halo3ODST, $@"{JSONFileTree.JSONCommandPath}generatecache\tags_odst.json" },
            { GeneratedCacheType.ElDewrito, $@"{JSONFileTree.JSONCommandPath}generatecache\tags_eldewrito.json" },
            { GeneratedCacheType.HaloOnline, $@"{JSONFileTree.JSONCommandPath}generatecache\tags_halo_online.json" },
        };

        public void ParseTagList(string jsonPath)
        {
            var jsonData = File.ReadAllText(jsonPath);
            TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in TagObjectList)
                TagParser.ParseFile(file);
        }

        public void UpdateTagData()
        {
            ParseTagList($@"{JSONFileTree.JSONCommandPath}generatecache\tags.json");

            if (CacheTypePath.TryGetValue(CacheType, out var jsonPath))
                ParseTagList(jsonPath);
        }

        public void UpdateMapData()
        {
            MapParser = new MapObjectParser(Cache, CacheContext, CacheStream);

            var jsonData = File.ReadAllText($@"{JSONFileTree.JSONCommandPath}generatecache\maps.json");
            MapObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in MapObjectList)
                MapParser.ParseFile(file);
        }

        public void UpdateBlfData()
        {
            BlfParser = new BlfObjectParser(Cache, CacheContext, CacheStream);

            var jsonData = File.ReadAllText($@"{JSONFileTree.JSONCommandPath}generatecache\blf.json");
            BlfObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in BlfObjectList)
                BlfParser.ParseFile(file);
        }
    }
}
