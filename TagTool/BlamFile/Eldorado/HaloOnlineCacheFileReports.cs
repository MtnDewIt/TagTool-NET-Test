using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Tags;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x4FC80, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline155080)]
    [TagStructure(Size = 0x61080, MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
    public class HaloOnlineCacheFileReports : TagStructure
    {
        [TagField(Length = 1184, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline155080)]
        [TagField(Length = 1440, MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
        public CacheFileReports.CacheFileReport[] Reports;

        public HaloOnlineCacheFileReports(CacheFileReports cacheFileReports) 
        {
            Reports = cacheFileReports.Reports;
        }
    }
}
