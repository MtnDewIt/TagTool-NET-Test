using TagTool.Cache;
using TagTool.IO;
using System.Collections.Generic;
using System.IO;
using System;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Tags;
using TagTool.Serialization;
using TagTool.Bitmaps;
using TagTool.Tags.Resources;
using TagTool.Bitmaps.Utils;
using TagTool.Bitmaps.DDS;
using TagTool.Geometry;
using TagTool.BlamFile;

namespace TagTool.Commands
{
    
    public class TestCommand : Command
    {
        GameCache Cache;

        public TestCommand(GameCache cache) : base(false, "Test", "Test", "Test", "Test")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 0)
                return false;

            var mapFilesFolder = new DirectoryInfo(@"D:\Halo\Maps\Halo3Beta");
            var outDir = new DirectoryInfo("CacheTest");
            if (!outDir.Exists)
                outDir.Create();

            var mapFiles = mapFilesFolder.GetFiles("*.map");

            //
            // Insert what test command you want below
            //
            var mapFile = new FileInfo(@"D:\Halo\Maps\HaloPC\a10.map");
            var mapName = mapFile.Name;
            Console.WriteLine($"{mapName}...");

            var map = new MapFile();

            var cache = GameCache.Open(mapFile);




            return true;
        }
    }
}

