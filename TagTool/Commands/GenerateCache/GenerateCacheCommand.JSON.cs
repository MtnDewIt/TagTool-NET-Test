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
            { GeneratedCacheType.Halo3, $@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_h3.json" },
            { GeneratedCacheType.Halo3Mythic, $@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_mythic.json" },
            { GeneratedCacheType.Halo3ODST, $@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_odst.json" },
            { GeneratedCacheType.ElDewrito, $@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_eldewrito.json" },
            { GeneratedCacheType.HaloOnline, $@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_halo_online.json" },
        };

        public void ParseTagList(string jsonPath)
        {
            var jsonData = File.ReadAllText(jsonPath);
            TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in TagObjectList)
                TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");
        }

        public void UpdateTagData()
        {
            ParseTagList($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags.json");

            if (CacheTypePath.TryGetValue(CacheType, out var jsonPath))
                ParseTagList(jsonPath);
        }

        public void UpdateMapData()
        {
            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\maps.json");
            MapObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in MapObjectList)
                MapParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\maps\{file}");
        }

        public void UpdateBlfData()
        {
            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\blf.json");
            BlfObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in BlfObjectList)
                BlfParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\{file}");
        }
    }
}
