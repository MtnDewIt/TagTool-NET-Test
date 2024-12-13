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
        private BlfObjectParser BlfParser;

        public void ParseJSONData(string jsonInputPath, string scenarioPath)
        {
            TagParser = new TagObjectParser(Cache, CacheContext, CacheStream, jsonInputPath);
            BlfParser = new BlfObjectParser(Cache, CacheContext, CacheStream, jsonInputPath);

            TagParser.ParseFile($@"global_tags.cache_file_global_tags");
            TagParser.ParseFile($@"{scenarioPath}.scenario");

            BlfParser.ParseFile($@"data\levels\halo3");
        }
    }
}
