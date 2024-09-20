using System;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class CampaignInfo : TagStructure
    {
        public Guid CampaignGuid;
        public string Title; // May need to wrap in an object
        public string Description; // May need to wrap in an object
        public List<string> CampaignMaps;
    }
}