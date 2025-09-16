using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.Eldorado
{
    [TagStructure(Size = 0x2CB15, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.EldoradoED)]
    [TagStructure(Size = 0x53010, MinVersion = CacheVersion.Eldorado106708, MaxVersion = CacheVersion.Eldorado155080)]
    [TagStructure(Size = 0x64410, MinVersion = CacheVersion.Eldorado235640, MaxVersion = CacheVersion.Eldorado700123)]
    public class EldoradoMapFile : TagStructure 
    {
        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public CacheFileHeader Header;

        [TagField(MaxVersion = CacheVersion.EldoradoED)]
        public EldoradoBlf Blf;

        [TagField(MinVersion = CacheVersion.Eldorado106708, MaxVersion = CacheVersion.Eldorado700123)]
        public EldoradoCacheFileReports Reports;

        public EldoradoMapFile(MapFile mapFileData) 
        {
            Header = mapFileData.Header;
            Blf = mapFileData.MapFileBlf != null ? new EldoradoBlf(mapFileData.MapFileBlf) : null;
            Reports = mapFileData.Reports != null ? new EldoradoCacheFileReports(mapFileData.Reports) : null;
        }
    }
}
