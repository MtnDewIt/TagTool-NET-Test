using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x2CB15, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
    [TagStructure(Size = 0x3390, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline700123)]
    public class HaloOnlineMapFile : TagStructure 
    {
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public CacheFileHeaderGenHaloOnline Header;

        [TagField(MaxVersion = CacheVersion.HaloOnlineED)]
        public HaloOnlineBlf Blf;

        public HaloOnlineMapFile(MapFile mapFileData) 
        {
            Header = mapFileData.Header as CacheFileHeaderGenHaloOnline;
            Blf = mapFileData.MapFileBlf != null ? new HaloOnlineBlf(mapFileData.MapFileBlf) : null;
        }
    }
}
