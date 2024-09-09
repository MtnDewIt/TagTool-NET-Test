using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.IO;
using TagTool.MtnDewIt.JSON.Objects;
using TagTool.MtnDewIt.JSON.Handlers;

namespace TagTool.Commands.JSON
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

            var file = new FileInfo(args[0]);
            var blfData = new Blf(Cache.Version, Cache.Platform);

            var fileName = Path.GetFileNameWithoutExtension(file.Name);
            var fileExtension = file.Extension.TrimStart('.');

            // Wrapping the whole thing in a using statement probably isn't the best idea
            using (var stream = file.OpenRead())
            {
                var reader = new EndianReader(stream);

                if (file.Name.EndsWith(".mapinfo"))
                {
                    if (reader.Length == 20113)
                    {
                        blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                    }

                    if (reader.Length == 39425)
                    {
                        blfData = new Blf(CacheVersion.Halo3ODST, Cache.Platform);
                    }
                }

                if (file.Name.EndsWith(".campaign"))
                {
                    ExportPath = $@"data\levels";
                }

                blfData.Read(reader);

                var blfObject = new BlfObject()
                {
                    FileName = fileName,
                    FileType = fileExtension,
                    Blf = blfData,
                };

                var jsonData = handler.Serialize(blfObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{fileName}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{fileName}.json"), jsonData);
            }

            return true;
        }
    }
}