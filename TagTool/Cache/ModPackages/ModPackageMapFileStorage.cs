using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.Cache.HaloOnline;

namespace TagTool.Cache.ModPackages
{
    public class ModPackageMapFileStorage : IMapFileStorage
    {
        private readonly ModPackage _package;
        private readonly GameCacheModPackage _modCache;

        public ModPackageMapFileStorage(GameCacheModPackage modCache)
        {
            _modCache = modCache;
            _package = modCache.BaseModPackage;
        }

        public MapFile[] GetAll()
        {
            return [.. _package.MapFiles.Select(entry => entry.MapFile)];
        }

        public MapFile FindByMapId(int mapId)
        {
            int mapIndex = FindMapByMapIdInternal(mapId);
            if (mapIndex != -1)
                return _package.MapFiles[mapIndex].MapFile;

            return null;
        }

        public MapFile FindByName(string name)
        {
            int mapIndex = FindMapByNameInternal(name);
            if (mapIndex != -1)
                return _package.MapFiles[mapIndex].MapFile;

            return null;
        }

        public void Add(MapFile mapFile, int cacheIndex, bool overwrite)
        {
            if (cacheIndex == -1)
                cacheIndex = _modCache.GetCurrentTagCacheIndex();

            var header = (CacheFileHeaderGenHaloOnline)mapFile.Header;
            int mapId = header.MapId;

            int mapIndex = FindMapByNameInternal(header.Name);
            if (mapIndex != -1 && !overwrite)
                throw new IOException($"A Map file with the map id '{mapId}' already exists");

            if (FindMapByNameInternal(header.Name) != -1 && !overwrite)
                throw new IOException($"A Map file with the name '{header.Name}' already exists");

            var newEntry = new ModPackage.MapFileEntry(mapFile, cacheIndex);
            if (mapIndex != -1)
                _package.MapFiles[mapIndex] = newEntry;
            else
                _package.MapFiles.Add(newEntry);
        }

        public void Delete(string name)
        {
            int mapIndex = FindMapByNameInternal(name);
            if (mapIndex != -1)
                _package.MapFiles.RemoveAt(mapIndex);
        }

        private int FindMapByNameInternal(string name)
        {
            return _package.MapFiles.FindIndex(entry =>
            {
                var entryHeader = (CacheFileHeaderGenHaloOnline)entry.MapFile.Header;
                return entryHeader.Name == name;
            });
        }

        private int FindMapByMapIdInternal(int mapId)
        {
            return _package.MapFiles.FindIndex(entry =>
            {
                var entryHeader = (CacheFileHeaderGenHaloOnline)entry.MapFile.Header;
                return entryHeader.MapId == mapId;
            });
        }
    }
}
