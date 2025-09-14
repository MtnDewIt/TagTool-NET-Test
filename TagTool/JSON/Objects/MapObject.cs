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
                        case CacheVersion.EldoradoED:
                        case CacheVersion.Eldorado106708:
                        case CacheVersion.Eldorado235640:
                        case CacheVersion.Eldorado301003:
                        case CacheVersion.Eldorado327043:
                        case CacheVersion.Eldorado372731:
                        case CacheVersion.Eldorado416097:
                        case CacheVersion.Eldorado430475:
                        case CacheVersion.Eldorado454665:
                        case CacheVersion.Eldorado449175:
                        case CacheVersion.Eldorado498295:
                        case CacheVersion.Eldorado530605:
                        case CacheVersion.Eldorado532911:
                        case CacheVersion.Eldorado554482:
                        case CacheVersion.Eldorado571627:
                        case CacheVersion.Eldorado604673:
                        case CacheVersion.Eldorado700123:
                            InlineHeader = (CacheFileHeader)Activator.CreateInstance(typeof(CacheFileHeaderEldorado));
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
