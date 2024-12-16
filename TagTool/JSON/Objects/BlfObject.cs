﻿using TagTool.Cache;
using TagTool.BlamFile;

namespace TagTool.JSON.Objects
{
    public class BlfObject
    {
        public string FileName { get; set; }
        public string FileType { get; set; }

        public Blf Blf { get; set; }
    }
}
