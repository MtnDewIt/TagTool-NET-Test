﻿namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "swear_filter_list", Tag = "swel", Size = 0x14)]
    public class SwearFilterList : TagStructure
    {
        [TagField(Length = 0x14)]
        public byte[] Data;
    }
}
