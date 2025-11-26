using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.IO;

namespace TagTool.Cache.HaloOnline
{
    public class DirectoryMapFileStorage : IMapFileStorage
    {
        private string _directory;

        public DirectoryMapFileStorage(string directory)
        {
            _directory = directory;
        }

        public MapFile[] GetAll()
        {
            var files = new List<MapFile>();
            foreach (string currentMapPath in GetMapFilePaths())
            {
                using var reader = new EndianReader(File.OpenRead(currentMapPath));
                files.Add(new MapFile(reader));
            }
            return [.. files];
        }

        public MapFile FindByMapId(int mapId)
        {
            foreach (string currentMapPath in GetMapFilePaths())
            {
                using var reader = new EndianReader(File.OpenRead(currentMapPath));
                reader.SeekTo(0x2DEC);

                int currentMapId = reader.ReadInt32();

                if (currentMapId == mapId)
                    return new MapFile(reader);
            }

            return null;
        }

        public MapFile FindByName(string name)
        {
            foreach (string currentMapPath in GetMapFilePaths())
            {
                using var reader = new EndianReader(File.OpenRead(currentMapPath));
                reader.SeekTo(0x1A4);

                string currentName = reader.ReadNullTerminatedString(32);

                if (currentName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return new MapFile(reader);
            }

            return null;
        }

        public void Add(MapFile mapFile, int cacheIndex = -1, bool overwrite = true)
        {
            string mapPath = GetMapFilePath(mapFile.Header.GetName());
            if (!overwrite && Path.Exists(mapPath))
                throw new IOException($"Map file '{mapPath}' already exists.");

            WriteMapFile(mapPath, mapFile);
        }

        public void Delete(string name)
        {
            File.Delete(GetMapFilePath(name));
        }

        private void WriteMapFile(string mapPath, MapFile mapFile)
        {
            using var writer = new IO.EndianWriter(File.Create(mapPath));
            mapFile.Write(writer);
        }

        private string GetMapFilePath(string name) => Path.Combine(_directory, $"{name}.map");
        private string[] GetMapFilePaths() => Directory.GetFiles(_directory, "*.map");
    }
}
