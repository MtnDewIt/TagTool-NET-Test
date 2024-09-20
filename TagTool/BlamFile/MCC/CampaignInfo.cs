using System;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class CampaignInfo : TagStructure
    {
        public Guid CampaignGuid;
        public LocalizedString Title;
        public LocalizedString Description;
        public List<string> CampaignMaps;
    }
}