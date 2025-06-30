﻿using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;

namespace TagTool.Commands.Shaders
{
    public class UseShaderCacheCommand : Command
    {
        public static GameCacheHaloOnline ShaderCache = null;

        public UseShaderCacheCommand() :
            base(true,

                "UseShaderCache",
                "Specify a directory to store shader cache",

                "UseShaderCache <Directory>",
                "")
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            var directory = new DirectoryInfo(args[0]);
            var tagsFile = new FileInfo(Path.Combine(directory.FullName, "tags.dat"));

            if (!directory.Exists || !tagsFile.Exists)
            {
                if (!directory.Exists)
                {
                    Console.Write("Shader cache directory does not exist. Creating...");
                    directory.Create();
                }

                ShaderCache = new GameCacheHaloOnline(directory);
            }
            else
            {
                ShaderCache = (GameCacheHaloOnline)GameCache.Open(tagsFile);
            }

            Console.WriteLine("Shader cache set successfully");
            return true;
        }
    }
}
