using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.Eldorado
{
    [TagStructure(Size = 0x4FC80, MinVersion = CacheVersion.Eldorado106708, MaxVersion = CacheVersion.Eldorado155080)]
    [TagStructure(Size = 0x61080, MinVersion = CacheVersion.Eldorado235640, MaxVersion = CacheVersion.Eldorado700123)]
    public class EldoradoCacheFileReports : TagStructure
    {
        [TagField(Length = 1184, MinVersion = CacheVersion.Eldorado106708, MaxVersion = CacheVersion.Eldorado155080)]
        [TagField(Length = 1440, MinVersion = CacheVersion.Eldorado235640, MaxVersion = CacheVersion.Eldorado700123)]
        public CacheFileReports.CacheFileReport[] Reports;

        public EldoradoCacheFileReports(CacheFileReports cacheFileReports) 
        {
            Reports = cacheFileReports.Reports;
        }
    }
}
