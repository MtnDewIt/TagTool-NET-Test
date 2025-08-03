using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.IO;
using static TagTool.BlamFile.Blf;

namespace TagTool.Commands.Files
{
    class ExtractBlfImageCommand : Command
    {
        public ExtractBlfImageCommand()
            : base(true,

                  "ExtractBlfImage",
                  "Extracts the image from a blf",

                  "ExtractBlfImage <blf path> <output jpg> [version]",
                  "Extracts the image from a blf")
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 2 || args.Count > 3)
                return new TagToolError(CommandError.ArgCount);

            FileInfo file = new FileInfo(args[0]);
            if (!file.Exists)
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\" does not exist at the specified path");

            FileInfo output = new FileInfo(args[1]);

            if (!output.Directory.Exists)
                output.Directory.Create();

            var blf = new Blf(CacheVersion.HaloOnlineED, CachePlatform.Original);

            using (var stream = file.OpenRead())
            using (var reader = new EndianReader(stream))
            {
                if (!blf.Read(reader))
                    return new TagToolError(CommandError.CustomError, "Could not parse BLF");
            }

            if (!blf.ContentFlags.HasFlag(BlfFileContentFlags.MapImage) || blf.Buffer == null || blf.Buffer.Length == 0)
                return new TagToolError(CommandError.CustomError, "BLF does not contain image");

            using (var stream = output.Create())
            {
                stream.Write(blf.Buffer, 0, blf.Buffer.Length);
            }

            return true;
        }
    }
}
