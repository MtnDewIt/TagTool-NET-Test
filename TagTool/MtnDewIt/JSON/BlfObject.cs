using TagTool.Cache;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.JSON
{
    public class BlfObject 
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public CacheVersion FileVersion { get; set; }

        public BlfData BlfData { get; set; }
    }
}
