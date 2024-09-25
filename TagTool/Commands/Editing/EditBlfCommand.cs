using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.IO;

namespace TagTool.Commands.Editing
{
    public class EditBlfCommand : Command 
    {
        private CommandContextStack ContextStack { get; }
        private GameCacheHaloOnlineBase CacheContext { get; }
        private GameCache Cache { get; }

        public EditBlfCommand(CommandContextStack contextStack, GameCacheHaloOnlineBase cacheContext, GameCache cache) : base(
            false,

            "EditBlf",
            "Edit blf file specific data",

            "EditBlf <Blf File>",

            "If the blf file contains data which is supported by this program,\n" +
            "this command will make special blf file specific commands available\n" +
            "which can be used to edit or view the data in the blf.")
        {
            ContextStack = contextStack;
            CacheContext = cacheContext;
            Cache = cache;
        }

        public override object Execute(List<string> args) 
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            if (!TryGetBlfFile(args[0].ToLower(), out var blf))
            {
                return new TagToolError(CommandError.FileNotFound, $"\"{args[0].ToLower()}\"");
            }

            ContextStack.Push(EditBlfContextFactory.Create(ContextStack, Cache, blf, args[0].ToLower()));


            return true;
        }

        public bool TryGetBlfFile(string input, out Blf result) 
        {
            try
            {
                var file = new FileInfo(input);

                var blfData = new Blf(Cache.Version, Cache.Platform);

                using (var stream = file.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    blfData.Read(reader);
                }

                result = blfData;

                return true;
            }
            catch
            {
                result = null;

                return false;
            }
        }
    }
}
