using System;
using TagTool.Cache;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.JSON.Objects
{
    public class MapObject
    {
        public string MapName { get; set; }
        public CacheVersion MapVersion { get; set; }

        private CacheFileHeader InlineCacheFileHeaderData { get; set; }
        public CacheFileHeader CacheFileHeaderData
        {
            get
            {
                if (InlineCacheFileHeaderData == null)
                {
                    if (MapVersion.GetGeneration() == CacheGeneration.HaloOnline)
                    {
                        InlineCacheFileHeaderData = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderGenHaloOnline));
                    }
                }

                return InlineCacheFileHeaderData;
            }
            set
            {
                InlineCacheFileHeaderData = value;
            }
        }
        public BlfData BlfData { get; set; }
    }
}
