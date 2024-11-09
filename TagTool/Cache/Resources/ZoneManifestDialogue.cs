using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Resources 
{
    [TagStructure(Size = 0x90, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0xAC, MinVersion = CacheVersion.HaloReach)]
    public class ZoneManifestDialogue : TagStructure 
    {
        public ZoneManifest ZoneManifest;

        public int DiskSize;
        public int UnusedSize;
        public CachedTag OwnerTag;
    }
}