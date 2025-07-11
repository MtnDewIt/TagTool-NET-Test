using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands.Common;

namespace TagTool.Commands.Files
{
    class UpdateMapFilesCommand : Command
    {
        public GameCache Cache { get; }

        public UpdateMapFilesCommand(GameCache cache)
            : base(true,

                  "UpdateMapFiles",
                  "Updates the game's .map files to contain valid scenario indices.",

                  "UpdateMapFiles <MapInfo Directory> [forceupdate]",

                  "Updates the game's .map files to contain valid scenario indices.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            bool forceUpdate = false;
            string mapInfoPath = "";

            if (args.Count >= 1)
            {
                if (!Directory.Exists(args[0]))
                    return new TagToolError(CommandError.ArgInvalid, "Given mapinfo directory does not exist.");
                else
                    mapInfoPath = args[0];
            }

            if (args.Count > 1 && args[1].Equals("forceupdate", StringComparison.CurrentCultureIgnoreCase))
                forceUpdate = true;

            MapFileUpdater.UpdateMapFiles(Cache, mapInfoPath, forceUpdate);

            return true;
        }
    }
}