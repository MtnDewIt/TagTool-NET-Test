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

        // If its always zero, then it might be padding
        // [TagField(Length = 0x4)]
        // publyc byte[] Padding = new byte[4]
        public int UnusedSize;

        public CachedTag OwnerTag;
    }
}