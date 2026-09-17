using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache.Gen3;
using TagTool.Commands.Common;

namespace TagTool.Commands.WeDontTalkAboutIt
{
    public class CompressCommand : Command
    {
        public CompressCommand() : base(
            false,
            "Compress",
            "Compresses a decompressed 2014 Xbox One Halo 3 MCC cache file in place",
            "Compress <Path>",
            "Compresses the map and replaces the same file directly.")
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            var inputFile = new FileInfo(args[0]);
            if (!inputFile.Exists)
                return new TagToolError(CommandError.FileNotFound, inputFile.FullName);

            MemoryStream compressed;
            using (var input = inputFile.OpenRead())
                compressed = DurangoCacheCompression.Compress(input);

            string tempPath = inputFile.FullName + ".tagtool-compress-" + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                compressed.Position = 0;
                using (var destination = new FileStream(tempPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    compressed.CopyTo(destination);
                    destination.Flush(true);
                }

                File.Move(tempPath, inputFile.FullName, true);
            }
            finally
            {
                compressed.Dispose();
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }

            Console.WriteLine($"Compressed cache replaced in place: {inputFile.FullName}");
            return true;
        }
    }
}
