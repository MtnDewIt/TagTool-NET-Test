using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.IO;

namespace TagTool.Commands.Tags
{
    class ListMapsCommand : Command 
    {
        private GameCacheHaloOnlineBase CacheContext { get; }

        public ListMapsCommand(GameCacheHaloOnlineBase cacheContext)
            : base(true,

                "ListMaps",
                "Lists all map files in the associcated cache.",

                "ListMaps",
                "Lists all map files in the associcated cache. TODO: ADD FILTERS")
        {
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args) 
        {
            List<string> maps = Directory.GetFiles($@"{CacheContext.Directory.FullName}", $@"*.map").ToList();

            foreach (var map in maps) 
            {
                var file = new FileInfo(map);

                var mapFile = new MapFile();

                using (var stream = file.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    mapFile.Read(reader);
                }

                var header = mapFile.Header as CacheFileHeaderGenHaloOnline;

                Console.WriteLine($@"[Size: 0x{header.FileLength:X4}, MapID: {header.MapId, -3}] {file.Name}");
            }

            return true;
        }
    }
}
