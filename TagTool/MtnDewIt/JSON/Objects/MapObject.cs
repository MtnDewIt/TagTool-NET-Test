using System;
using TagTool.Cache;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.JSON.Objects
{
    public class MapObject
    {
        public string MapName { get; set; }
        public CacheVersion MapVersion { get; set; }

        private CacheFileHeaderData InlineCacheFileHeaderData { get; set; }
        public CacheFileHeaderData CacheFileHeaderData
        {
            get
            {
                if (InlineCacheFileHeaderData == null)
                {
                    if (MapVersion.GetGeneration() == CacheGeneration.HaloOnline)
                    {
                        InlineCacheFileHeaderData = (CacheFileHeaderData)Activator.CreateInstance(typeof(CacheFileHeaderDataHaloOnline));
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
