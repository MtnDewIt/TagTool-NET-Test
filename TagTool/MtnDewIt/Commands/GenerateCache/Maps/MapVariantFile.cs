using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.IO;
using System.Linq;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags.Definitions;
using TagTool.Tags;
using TagTool.Commands.Common;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Maps
{
    public abstract class MapVariantFile
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public Stream Stream { get; set; }

        public MapVariantFile(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
        }

        public void GenerateMapFile(CachedTag scnrTag, Scenario scnr, BlfData mapVariant)
        {
            MapFileData mapFileData;

            mapFileData = GenerateMap(scnrTag, scnr, mapVariant, Cache.Endianness, Cache.Version);

            var mapFilePath = $"{Path.Combine(Cache.Directory.FullName, scnrTag.Name.Split('\\').Last())}.map";
            var mapFile = new FileInfo(mapFilePath);

            using (var stream = mapFile.Create())
            using (var writer = new EndianWriter(stream))
            {
                mapFileData.WriteData(writer);
            }
        }

        public MapFileData GenerateMap(CachedTag scnrTag, Scenario scnr, BlfData mapVariant, EndianFormat format, CacheVersion version)
        {
            var mapFile = new MapFileData();
            mapFile.Version = version;
            mapFile.CachePlatform = CachePlatform.Original;
            mapFile.EndianFormat = format;
            mapFile.MapVersion = CacheFileVersion.HaloOnline;
            var header = new CacheFileHeaderGenHaloOnline();
            header.HeaderSignature = new Tag("head");
            header.FileVersion = CacheFileVersion.HaloOnline;
            header.FileLength = (int)TagStructure.GetStructureSize(typeof(CacheFileHeaderGenHaloOnline), version, CachePlatform.Original);
            header.Build = CacheVersionDetection.GetBuildName(version, CachePlatform.Original);

            switch (scnr.MapType)
            {
                case ScenarioMapType.MainMenu:
                    header.CacheType = CacheFileType.MainMenu;
                    break;
                case ScenarioMapType.SinglePlayer:
                    header.CacheType = CacheFileType.Campaign;
                    break;
                case ScenarioMapType.Multiplayer:
                    header.CacheType = CacheFileType.Multiplayer;
                    break;
            }

            header.SharedCacheType = CacheFileSharedType.None;
            header.Name = scnrTag.Name.Split('\\').Last();
            header.ScenarioPath = scnrTag.Name;
            header.MapId = scnr.MapId;
            header.ScenarioTagIndex = scnrTag.Index;
            header.FooterSignature = new Tag("foot");
            mapFile.Header = header;
            mapFile.MapFileBlf = mapVariant;
            return mapFile;
        }

        public void GenerateCampaignFile() 
        {
            // TODO: Implement
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }

        public abstract void MapVariantData();
    }
}