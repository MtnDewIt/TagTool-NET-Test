using System;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class CampaignMapInfo : TagStructure
    {
        public Guid MapGuid;
        public string ScenarioFile;
        public string Title;
        public string Description;
        public MapImageInfo Images;
        public List<InsertionPointInfo> InsertionPoints;
        public CampaignMapKind CampaignMapKind;
        public CampaignMetagameInfo CampaignMetagame;
    }

    public enum CampaignMapKind
    {
        Invalid = -1,
        Default = 0,
        Tutorial = 1,
        Prologue = 2,
        Epilogue = 3,
        SupportsFirefight = 4,
        Count = 5,
    }

    public class CampaignMetagameInfo
    {
        public bool IsNonScoring;
		public uint MissionSegmentCount;
		public float ParTimeInSeconds;
		public float AverageTimeInSeconds;
		public float MaxTimeInSeconds;
    }
}