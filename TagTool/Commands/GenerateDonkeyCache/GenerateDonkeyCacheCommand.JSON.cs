using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.JSON;
using TagTool.JSON.Parsers;

namespace TagTool.Commands.GenerateDonkeyCache
{
    partial class GenerateDonkeyCacheCommand : Command
    {
        private TagObjectParser TagParser;
        private MapObjectParser MapParser;
        private BlfObjectParser BlfParser;

        private List<string> TagObjectList;
        private List<string> MapObjectList;
        private List<string> BlfObjectList;

        public void ParseTagList(string jsonPath)
        {
            var jsonData = File.ReadAllText(jsonPath);
            TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in TagObjectList)
                TagParser.ParseFile(file);
        }

        public void UpdateTagData()
        {
            ParseTagList($@"{SourceDirectoryInfo.FullName}\tags.json");
        }

        public void UpdateMapData()
        {
            var jsonData = File.ReadAllText($@"{SourceDirectoryInfo.FullName}\maps.json");
            MapObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in MapObjectList)
                MapParser.ParseFile(file);
        }

        public void UpdateBlfData()
        {
            var jsonData = File.ReadAllText($@"{SourceDirectoryInfo.FullName}\blf.json");
            BlfObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in BlfObjectList)
                BlfParser.ParseFile(file);
        }
    }
}
