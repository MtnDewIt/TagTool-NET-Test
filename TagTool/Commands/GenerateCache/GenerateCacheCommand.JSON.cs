using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.JSON;
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
            { GeneratedCacheType.Halo3, $@"{JSONFileTree.JSONGenerateCachePath}\tags_h3.json" },
            { GeneratedCacheType.Halo3Mythic, $@"{JSONFileTree.JSONGenerateCachePath}\tags_mythic.json" },
            { GeneratedCacheType.Halo3ODST, $@"{JSONFileTree.JSONGenerateCachePath}\tags_odst.json" },
            { GeneratedCacheType.ElDewrito, $@"{JSONFileTree.JSONGenerateCachePath}\tags_eldewrito.json" },
            { GeneratedCacheType.HaloOnline, $@"{JSONFileTree.JSONGenerateCachePath}\tags_halo_online.json" },
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
            ParseTagList($@"{JSONFileTree.JSONGenerateCachePath}\tags.json");

            if (CacheTypePath.TryGetValue(CacheType, out var jsonPath))
                ParseTagList(jsonPath);
        }

        public void UpdateMapData()
        {
            MapParser = new MapObjectParser(Cache, CacheContext, CacheStream, JSONFileTree.JSONGenerateCachePath);

            var jsonData = File.ReadAllText($@"{JSONFileTree.JSONGenerateCachePath}\maps.json");
            MapObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in MapObjectList)
                MapParser.ParseFile(file);
        }

        public void UpdateBlfData()
        {
            BlfParser = new BlfObjectParser(Cache, CacheContext, CacheStream, JSONFileTree.JSONGenerateCachePath);

            var jsonData = File.ReadAllText($@"{JSONFileTree.JSONGenerateCachePath}\blf.json");
            BlfObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in BlfObjectList)
                BlfParser.ParseFile(file);
        }
    }
}
