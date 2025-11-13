using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x2CB15, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
    [TagStructure(Size = 0x53010, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline155080)]
    [TagStructure(Size = 0x64410, MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
    public class HaloOnlineMapFile : TagStructure 
    {
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public CacheFileHeader Header;

        [TagField(MaxVersion = CacheVersion.HaloOnlineED)]
        public HaloOnlineBlf Blf;

        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline700123)]
        public HaloOnlineCacheFileReports Reports;

        public HaloOnlineMapFile(MapFile mapFileData) 
        {
            Header = mapFileData.Header;
            Blf = mapFileData.MapFileBlf != null ? new HaloOnlineBlf(mapFileData.MapFileBlf) : null;
            Reports = mapFileData.Reports != null ? new HaloOnlineCacheFileReports(mapFileData.Reports) : null;
        }
    }
}
