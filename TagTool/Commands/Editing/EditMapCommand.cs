using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.IO;

namespace TagTool.Commands.Editing 
{
    public class EditMapCommand : Command 
    {
        private CommandContextStack ContextStack { get; }
        private GameCache Cache { get; }
        private MapFile MapFile { get; set; }

        public EditMapCommand(CommandContextStack contextStack, GameCache cache) : base(
            false,

            "EditMap",
            "Edit map-specific data",

            "EditMap <Map File>",

            "If the map file contains data which is supported by this program,\n" +
            "this command will make special map-specific commands available\n" +
            "which can be used to edit or view the data in the map.")
        {
            ContextStack = contextStack;
            Cache = cache;
            MapFile = null;
        }

        public override object Execute(List<string> args) 
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            var mapName = args[0].ToLower().Replace(".map", "");

            if (Cache is GameCacheModPackage modCache)
            {
                MapFile = modCache.MapFiles.FindByName(mapName);

                if (MapFile == null) 
                {
                    throw new InvalidOperationException("Map not found in in mod package");
                }

                ContextStack.Push(EditMapContextFactory.Create(ContextStack, Cache, MapFile));
            }
            else if (Cache is GameCacheHaloOnline hoCache)
            {
                MapFile = hoCache.MapFiles.FindByName(mapName);

                if (MapFile == null) 
                {
                    throw new InvalidOperationException("Map not found in in cache directory");
                }

                ContextStack.Push(EditMapContextFactory.Create(ContextStack, Cache, MapFile));
            }

            return true;
        }
    }
}