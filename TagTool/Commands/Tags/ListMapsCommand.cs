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

            string columnFormat = "{0,-10} {1,-20} {2,-20} {3,-50} {4,-20}";
            Console.WriteLine(new string('-', 120));
            Console.WriteLine(columnFormat, "Map Id", "File Name", "Map Name", "Scenario", "Map Variant");
            Console.WriteLine(new string('-', 120));

            foreach (var map in maps) 
            {
                var file = new FileInfo(map);

                var mapFile = new MapFile();

                using (var stream = file.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    mapFile.Read(reader);

                    var header = mapFile.Header as CacheFileHeaderGenHaloOnline;
                    var mapVariant = mapFile.MapFileBlf?.MapVariant?.MapVariant;
                    var mapName = mapFile.MapFileBlf?.Scenario?.Names[0]?.Name;

                    Console.WriteLine(columnFormat, header.MapId, header.Name, mapName == null ? "None" : mapName, header.ScenarioPath, mapVariant == null ? "None" : mapVariant.Metadata.Name);
                }
            }

            return true;
        }
    }
}
