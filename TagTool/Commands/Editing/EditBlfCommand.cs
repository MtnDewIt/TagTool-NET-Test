using System;
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

            if (!TryGetBlfFile(args[0], out var blf))
            {
                return new TagToolError(CommandError.OperationFailed);
            }

            ContextStack.Push(EditBlfContextFactory.Create(ContextStack, Cache, blf, args[0].ToLower()));


            return true;
        }

        public bool TryGetBlfFile(string input, out Blf result) 
        {
            try
            {
                var file = new FileInfo(input);

                Blf blfData = null;

                using (var stream = file.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    switch (file.Extension)
                    {
                        case ".assault":
                        case ".ctf":
                        case ".jugg":
                        case ".koth":
                        case ".oddball":
                        case ".slayer":
                        case ".terries":
                        case ".vip":
                        case ".zombiez":
                        case ".map":
                            // I might add support for halo 3 variants at some point, but I'm not all that familiar
                            // with the formatting for variants outside of ED, so for now we'll only support ED variants.
                            blfData = new Blf(CacheVersion.HaloOnlineED, Cache.Platform);
                            break;
                        case ".bin":
                        case ".blf":
                            blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                            break;
                        case ".campaign":
                            blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                            break;
                        case ".mapinfo":
                            switch (reader.Length)
                            {
                                case 0x4E91:
                                    blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                                    break;
                                case 0x9A01:
                                    blfData = new Blf(CacheVersion.Halo3ODST, Cache.Platform);
                                    break;
                                case 0xCDD9:
                                    blfData = new Blf(CacheVersion.HaloReach, Cache.Platform);
                                    break;
                            }
                            break;
                        default:
                            blfData = new Blf(Cache.Version, Cache.Platform);
                            break;
                    }

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
