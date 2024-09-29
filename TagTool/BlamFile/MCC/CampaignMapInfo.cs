using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class CampaignMapInfo : TagStructure
    {
        public Guid MapGuid;
        public string ScenarioFile;
        public LocalizedString Title;
        public LocalizedString Description;
        public MapImageInfo Images;
        public List<InsertionPointInfo> InsertionPoints;
        public CampaignMapKinds CampaignMapKind;
        public CampaignMetagameInfo CampaignMetagame;

        public enum CampaignMapKinds
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

        public void ConvertCampaignMapInfo(BlfScenario scenario)
        {
            //scenario.MapId = GetMapId(ScenarioFile);

            var parsedTitle = Title.ParseLocalizedString(31, "Title");
            var parsedDescription = Description.ParseLocalizedString(127, "Description");

            for (int i = 0; i < scenario.Names.Length; i++)
                scenario.Names[i].Name = parsedTitle;

            for (int i = 0; i < scenario.Descriptions.Length; i++)
                scenario.Descriptions[i].Name = parsedDescription;

            scenario.ScenarioPath = ScenarioFile;
            scenario.ImageFileBase = $"m_{ScenarioFile.Split('\\').Last()}";

            //scenario.MinimumDesiredPlayers = 2;
            //scenario.MaximumDesiredPlayers = 6;
            //scenario.GameEngineTeamCounts = new GameEngineTeams
            //{
            //    NoGametypeTeamCount = 0,
            //    CtfTeamCount = 2,
            //    SlayerTeamCount = 8,
            //    OddballTeamCount = 8,
            //    KingTeamCount = 8,
            //    SandboxTeamCount = 8,
            //    VipTeamCount = 8,
            //    JuggernautTeamCount = 8,
            //    TerritoriesTeamCount = 4,
            //    AssaultTeamCount = 2,
            //    InfectionTeamCount = 8,
            //};

            //scenario.MapFlags = BlfScenarioFlags.GeneratesFilm;
            //switch (scnr.MapType)
            //{
            //    case ScenarioMapType.MainMenu:
            //        scenario.MapFlags |= BlfScenarioFlags.IsMainmenu;
            //        break;
            //    case ScenarioMapType.Multiplayer:
            //        scenario.MapFlags |= BlfScenarioFlags.IsMultiplayer;
            //        break;
            //    case ScenarioMapType.SinglePlayer:
            //        scenario.MapFlags |= BlfScenarioFlags.IsCampaign;
            //        break;
            //}

            for (int i = 0; i < InsertionPoints.Count; i++)
                InsertionPoints[i].ConvertInsertionPointInfo(scenario.Insertions[i], i);
        }
    }
}