﻿using TagTool.Shaders;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "global_cache_file_pixel_shaders", Tag = "gpix", Size = 0x1C)]
    public class GlobalCacheFilePixelShaders : TagStructure
    {
        public uint ShaderCount;
        public uint CachedShaderCount;
        public uint TotalMemorySize;
        public uint CachedMemorySize;
        public List<PixelShaderBlock> Shaders;
    }
}
