using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands
{
    class GenerateMapFilesCommand : Command
    {
        public GameCache Cache { get; set; }

        public GenerateMapFilesCommand(GameCache cache) : base
        (
            true,
            "GenerateMapFiles",
            "Generates new .map files containing valid scenario and map data.",
            "GenerateMapFiles  <MapInfo Directory> [forceupdate]",
            "Generates new .map files containing valid scenario and map data."
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            return true;            
        }
    }
}