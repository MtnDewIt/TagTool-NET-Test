using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x4FC80, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
    [TagStructure(Size = 0x61080, MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
    public class HaloOnlineCacheFileReports : TagStructure
    {
        [TagField(Length = 0x4A0, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        [TagField(Length = 0x5A0, MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
        public CacheFileReports.CacheFileReport[] Reports;

        public HaloOnlineCacheFileReports(CacheFileReports cacheFileReports) 
        {
            Reports = cacheFileReports.Reports;
        }
    }
}
