using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.HaloOnline;
using TagTool.Cache;
using TagTool.IO;

namespace TagTool.Commands.Editing
{
    public class SaveBlfChangesCommand : Command
    {
        private GameCache Cache { get; }
        private HaloOnlineBlf Blf { get; }
        private string FilePath;

        public SaveBlfChangesCommand(GameCache cache, HaloOnlineBlf blf, string filePath)
            : base(true,
                  "SaveBlfChanges",
                  $"Saves changes made to the current {Path.GetFileName(filePath)} file instance.",
                  "SaveBlfChanges",                   
                  $"Saves changes made to the current {Path.GetFileName(filePath)} file instance.")
        {
            Cache = cache;
            Blf = blf;
            FilePath = filePath;
        }

        public override object Execute(List<string> args) 
        {
            var blfData = new Blf(Cache.Version, Cache.Platform)
            {
                Format = Blf.Format,
                ContentFlags = Blf.ContentFlags,
                AuthenticationType = Blf.AuthenticationType,

                StartOfFile = Blf.StartOfFile,
                EndOfFileCRC = Blf.EndOfFileCRC,
                EndOfFileRSA = Blf.EndOfFileRSA,
                EndOfFileSHA1 = Blf.EndOfFileSHA1,
                EndOfFile = Blf.EndOfFile,
                Author = Blf.Author,
                Campaign = Blf.Campaign,
                Scenario = Blf.Scenario,
                ModReference = Blf.ModReference,
                MapVariantTagNames = Blf.MapVariantTagNames,
                MapVariant = Blf.MapVariant,
                GameVariant = Blf.GameVariant,
                ContentHeader = Blf.ContentHeader,
                MapImage = Blf.MapImage,
                Buffer = Blf.Buffer,
            };

            var file = new FileInfo(FilePath);

            using (var fileStream = file.OpenWrite())
            using (var writer = new EndianWriter(fileStream))
            {
                blfData.Write(writer);
            }

            return true;
        }
    }
}
