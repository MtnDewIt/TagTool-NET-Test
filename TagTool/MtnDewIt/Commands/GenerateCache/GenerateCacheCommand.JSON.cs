using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command 
    {
        private TagObjectParser TagParser;
        private MapObjectParser MapParser;
        private BlfObjectParser BlfParser;

        private List<string> TagObjectList;
        private List<string> MapObjectList;
        private List<string> BlfObjectList;

        // TODO: Add Tag Support :/
        // I will come back to you at some point, as I need to figure out how to handle resource data :/
        // I don't want to store any resource data in JSON, as that data is cache specific, and will not transfer over to a generated cache
        public void UpdateTagData()
        {
            TagParser = new TagObjectParser(Cache, CacheContext, CacheStream);
        
            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags.json");
            TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in TagObjectList)
                TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

            switch (CacheType)
            {
                case GeneratedCacheType.Halo3:
                    var jsonDataH3 = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_h3.json");
                    TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonDataH3);

                    foreach (var file in TagObjectList)
                        TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

                    break;
                case GeneratedCacheType.Halo3Mythic:
                    var jsonDataH3M = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_mythic.json");
                    TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonDataH3M);

                    foreach (var file in TagObjectList)
                        TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

                    break;
                case GeneratedCacheType.Halo3ODST:
                    var jsonDataODST = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_odst.json");
                    TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonDataODST);

                    foreach (var file in TagObjectList)
                        TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

                    break;
                case GeneratedCacheType.ElDewrito:
                    var jsonDataED = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_eldewrito.json");
                    TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonDataED);

                    foreach (var file in TagObjectList)
                        TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

                    break;
                case GeneratedCacheType.HaloOnline:
                    var jsonDataHO = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\tags_halo_online.json");
                    TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonDataHO);

                    foreach (var file in TagObjectList)
                        TagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

                    break;
            }
        }

        public void UpdateMapData()
        {
            MapParser = new MapObjectParser(Cache, CacheContext, CacheStream);

            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\maps.json");
            MapObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in MapObjectList)
                MapParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\maps\{file}");
        }

        public void UpdateBlfData()
        {
            BlfParser = new BlfObjectParser(Cache, CacheContext, CacheStream);

            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache\blf.json");
            BlfObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in BlfObjectList)
                BlfParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\{file}");
        }
    }
}
