using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.Cache.HaloOnline;
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

                  "GenerateCampaignFile <MapInfo Directory>",

                  "Generate the halo3.campaign file for the specificed map info folder")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            var mapInfoDir = Path.GetFullPath(args[0]);

            if (!File.Exists(Path.Combine(mapInfoDir, $"halo3.campaign")))
                return new TagToolError(CommandError.FileNotFound);

            CampaignFileGenerator.GenerateCampaignFile(Cache, mapInfoDir);
        
            Console.WriteLine("Done!");
            return true;
        }
    }
}