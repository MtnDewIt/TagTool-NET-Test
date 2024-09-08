using System;
using TagTool.Cache;
using TagTool.BlamFile;

namespace TagTool.MtnDewIt.JSON.Objects
{
    public class MapObject
    {
        public string MapName { get; set; }
        public CacheVersion MapVersion { get; set; }

        private CacheFileHeader InlineHeader { get; set; }
        public CacheFileHeader Header
        {
            get
            {
                if (InlineHeader == null)
                {
                    if (MapVersion.GetGeneration() == CacheGeneration.HaloOnline)
                    {
                        InlineHeader = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderGenHaloOnline));
                    }
                }

                return InlineHeader;
            }
            set
            {
                InlineHeader = value;
            }
        }
        public Blf MapFileBlf { get; set; }
    }
}
