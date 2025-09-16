using System;
using TagTool.Cache;
using TagTool.BlamFile;
using TagTool.Cache.Eldorado;

namespace TagTool.JSON.Objects
{
    public class MapObject
    {
        public string MapName { get; set; }
        public CacheVersion Version { get; set; }
        public CachePlatform Platform { get; set; }

        private CacheFileHeader InlineHeader { get; set; }
        public CacheFileHeader Header
        {
            get
            {
                if (InlineHeader == null)
                {
                    Type headerType = CacheFileHeader.GetHeaderType(Version, Platform);

                    InlineHeader = (CacheFileHeader)Activator.CreateInstance(headerType);
                }

                return InlineHeader;
            }
            set
            {
                InlineHeader = value;
            }
        }
        public Blf MapFileBlf { get; set; }
        public CacheFileReports Reports { get; set; }
    }
}
