using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "user_interface_fourth_wall_timing_definition", Tag = "fwtg", Size = 0x18, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    public class UserInterfaceFourthWallTimingDefinition : TagStructure
    {
        public List<DisplayGroupItem> DisplayGroups;
        public List<TextItem> Text;

        [TagStructure(Size = 0x10, Version = CacheVersion.Halo3ODST)]
        public class DisplayGroupItem : TagStructure 
        {
            public StringId DisplayGroup;
            public List<Timings> LocalizedTimings;
        }

        [TagStructure(Size = 0x10, Version = CacheVersion.Halo3ODST)]
        public class TextItem : TagStructure 
        {
            public StringId Text;
            public List<Timings> LocalizedTimings;
        }

        [TagStructure(Size = 0x8, Version = CacheVersion.Halo3ODST)]
        public class Timings : TagStructure
        {
            public GameLanguage Langauge;
            public float StartTime;
        }
    }
}
