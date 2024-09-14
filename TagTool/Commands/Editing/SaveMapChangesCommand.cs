using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.IO;

namespace TagTool.Commands.Editing
{
    class SaveMapChangesCommand : Command 
    {
        private GameCache Cache { get; }
        private MapFile MapFile { get; }

        public SaveMapChangesCommand(GameCache cache, MapFile mapFile)
            : base(true,
                  "SaveMapChanges",
                  $"Saves changes made to the current {mapFile.Header.GetName()}.map file instance.",
                  "SaveMapChanges",
                  $"Saves changes made to the current {mapFile.Header.GetName()}.map file instance.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            var file = new FileInfo($@"{Cache.Directory.FullName}\{MapFile.Header.GetName()}");

            using (var fileStream = file.OpenRead())
            using (var writer = new EndianWriter(fileStream)) 
            {
                MapFile.Write(writer);
            }

            return true;
        }
    }
}
