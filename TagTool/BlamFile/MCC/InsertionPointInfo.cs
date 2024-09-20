using System;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class InsertionPointInfo : TagStructure
    {
        public string ZoneSetName;
        public int ZoneSetIndex;
        public bool Valid;
        public string Title;
        public string Description;
        public ODSTInfo ODST;
        public string Thumbnail;
    }

    public class ODSTInfo
    {
        public bool IsFirefight;
        public Guid ReturnFromMapGuid;
    }
}