using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.MtnDewIt.JSON;
using TagTool.MtnDewIt.JSON.Handlers;

namespace TagTool.MtnDewIt.Commands 
{
    public class GenerateBlfObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private string ExportPath = $@"maps\info";

        public GenerateBlfObjectCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            false,
            "GenerateBlfObject",
            "Generates a JSON blf object file based on the specified blf file",

            "GenerateBlfObject <File_Path>",
            "Generates a JSON blf object file based on the specified blf file"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            var handler = new BlfObjectHandler(Cache, CacheContext);

            // TODO: Add exceptions for different blf file types
            var file = new FileInfo(args[0]);
            var blfData = new BlfData(Cache.Version, Cache.Platform);

            // Wrapping the whole thing in a using statement probably isn't the best idea
            using (var stream = file.OpenRead())
            {
                var reader = new EndianReader(stream);

                blfData.ReadData(reader);

                var blfObject = new BlfObject() 
                {
                    FileName = file.Name,
                    FileType = file.Extension.Trim(),
                    FileVersion = blfData.Version,
                    BlfData = blfData,
                };

                var jsonData = handler.Serialize(blfObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{file.Name}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{file.Name}.json"), jsonData);
            }

            return true;
        }
    }
}