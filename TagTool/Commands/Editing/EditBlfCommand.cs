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

                    var format = GetEndianFormat(reader);

                    switch (file.Extension)
                    {
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
                                default:
                                    blfData = new Blf(Cache.Version, Cache.Platform);
                                    break;
                            }
                            break;
                        case ".map":
                            switch (format) 
                            {
                                // TODO: Add MCC Map Variant Support (Halo 3, Reach)
                                // TODO: Maybe add 360 Reach Map Variant Support?
                                case EndianFormat.BigEndian:
                                    switch (reader.Length) 
                                    {
                                        // May need to add extra cases as the EOF chunk size differs slightly for some reason
                                        case 0xE1E9:
                                        case 0xE1F0:
                                            blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                                            break;
                                        default:
                                            blfData = new Blf(Cache.Version, Cache.Platform);
                                            break;
                                    }
                                    break;
                                case EndianFormat.LittleEndian:
                                    blfData = new Blf(CacheVersion.HaloOnlineED, Cache.Platform);
                                    break;
                                default:
                                    blfData = new Blf(Cache.Version, Cache.Platform);
                                    break;
                            }
                            break;
                        default:
                            switch (format)
                            {
                                case EndianFormat.BigEndian:
                                    blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                                    break;
                                case EndianFormat.LittleEndian:
                                    blfData = new Blf(CacheVersion.HaloOnlineED, Cache.Platform);
                                    break;
                                default:
                                    blfData = new Blf(Cache.Version, Cache.Platform);
                                    break;
                            }
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

        public EndianFormat GetEndianFormat(EndianReader reader) 
        {
            reader.Format = EndianFormat.LittleEndian;
            var startOfFile = reader.Position;
            reader.SeekTo(startOfFile + 0xC);
            if (reader.ReadInt16() == -2)
            {
                reader.SeekTo(startOfFile);
                return EndianFormat.LittleEndian;
            }
            else
            {
                reader.SeekTo(startOfFile + 0xC);
                reader.Format = EndianFormat.BigEndian;
                if (reader.ReadInt16() == -2)
                {
                    reader.SeekTo(startOfFile);
                    return EndianFormat.BigEndian;
                }
                else
                {
                    reader.SeekTo(startOfFile);
                    throw new Exception("Invalid BOM found in BLF start of file chunk");
                }
            }
        }
    }
}
