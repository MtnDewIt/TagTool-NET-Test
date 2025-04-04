﻿using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "scenario_required_resource", Tag = "sdzg", Size = 0xC, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    public class ScenarioRequiredResource : TagStructure
    {
        public List<RequiredObject> RequiredObjects;

        [TagStructure(Size = 0x10)]
        public class RequiredObject : TagStructure
        {
            public CachedTag Object;
        }
    }
}
