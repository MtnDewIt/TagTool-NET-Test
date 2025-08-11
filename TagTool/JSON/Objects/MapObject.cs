using System;
using TagTool.Cache;
using TagTool.BlamFile;

namespace TagTool.JSON.Objects
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
                    switch (MapVersion) 
                    {
                        case CacheVersion.HaloPC:
                        case CacheVersion.HaloXbox:
                        case CacheVersion.HaloCustomEdition:
                            InlineHeader = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderGen1));
                            break;
                        case CacheVersion.Halo2Alpha:
                        case CacheVersion.Halo2Beta:
                        case CacheVersion.Halo2Xbox:
                        case CacheVersion.Halo2PC:
                            InlineHeader = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderGen2));
                            break;
                        case CacheVersion.Halo3Beta:
                        case CacheVersion.Halo3Retail:
                        case CacheVersion.Halo3ODST:
                        case CacheVersion.HaloReach:
                        case CacheVersion.HaloReach11883:
                            InlineHeader = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderGen3));
                            break;
                        case CacheVersion.HaloOnlineED:
                        case CacheVersion.HaloOnline106708:
                        case CacheVersion.HaloOnline235640:
                        case CacheVersion.HaloOnline301003:
                        case CacheVersion.HaloOnline327043:
                        case CacheVersion.HaloOnline372731:
                        case CacheVersion.HaloOnline416097:
                        case CacheVersion.HaloOnline430475:
                        case CacheVersion.HaloOnline454665:
                        case CacheVersion.HaloOnline449175:
                        case CacheVersion.HaloOnline498295:
                        case CacheVersion.HaloOnline530605:
                        case CacheVersion.HaloOnline532911:
                        case CacheVersion.HaloOnline554482:
                        case CacheVersion.HaloOnline571627:
                        case CacheVersion.HaloOnline604673:
                        case CacheVersion.HaloOnline700123:
                            InlineHeader = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderGenHaloOnline));
                            break;
                        case CacheVersion.Halo4:
                        case CacheVersion.Halo2AMP:
                            InlineHeader = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderGen4));
                            break;
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
        public CacheFileReports Reports { get; set; }
    }
}
