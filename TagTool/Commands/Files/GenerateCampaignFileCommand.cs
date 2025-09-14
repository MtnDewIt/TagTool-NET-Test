using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.Cache.Eldorado;
using TagTool.Commands.Common;

namespace TagTool.Commands.Files
{
    class GenerateCampaignFileCommand : Command
    {
        public GameCache Cache { get; }

        public GenerateCampaignFileCommand(GameCache cache)
            : base(true,

                  "GenerateCampaignFile",
                  "Generate the halo3.campaign file for the specificed map info folder",

                  "GenerateCampaignFile [MapInfo Directory]",

                  "Generate the halo3.campaign file for the specificed map info folder")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 1)
                return new TagToolError(CommandError.ArgCount);

            // TODO: Should probably refactor all this :/
            // Thx unk for revealing how ass my implementation is lmao

            DirectoryInfo mapInfoDir = args.Count > 0 ? new DirectoryInfo(args[0]) : null;
            FileInfo modInfo = mapInfoDir != null ? new FileInfo(Path.Combine(mapInfoDir.FullName, "ModInfo.json")) : null;
            FileInfo mapInfo = mapInfoDir != null ? new FileInfo(Path.Combine(mapInfoDir.FullName, "halo3.campaign")) : null;

            if (mapInfoDir != null && !mapInfo.Exists && !modInfo.Exists)
                return new TagToolError(CommandError.FileNotFound);

            CampaignFileGenerator.GenerateCampaignFile(Cache, mapInfo, modInfo);

            Console.WriteLine("Done!");
            return true;
        }
    }
}