using System;
using TagTool.Audio;

namespace TagTool.MtnDewIt.Porting
{
    public class PortingProperties
    {
        // Maximum number of threads to use
        public int MaxThreads = Environment.ProcessorCount * 2;
        
        // Audio codec to use for ported sounds
        public Compression AudioCodec = Compression.MP3;
        
        // Path to reach lightmap cache directory
        public string ReachLightmapCache = null;
        
        // Enable reach decorator porting (WIP)
        public bool ReachDecorators = true;
        
        // Enable legacy Gen1 collision BSP generator
        public bool Gen1Collision = false;
        
        // Convert CTX1 bitmaps to DXN (default is DXT1)
        public bool HqNormalMapConversion = true;
    }
}