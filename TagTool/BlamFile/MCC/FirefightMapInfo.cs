using System;
using System.Collections.Generic;
using TagTool.Tags;
using System.Linq;

namespace TagTool.BlamFile.MCC
{
    public class FirefightMapInfo : TagStructure
    {
        public Guid MapGuid;
        public string ScenarioFile;
        public LocalizedString Title;
        public LocalizedString Description;
        public MapImageInfo Images;
        public List<InsertionPointInfo> InsertionPoints;
        public DamageReportingType MapDefaultPrimaryWeapon;

        public void ConvertFirefightMapInfo(BlfScenario scenario) 
        {
            //scenario.MapId = GetMapId(ScenarioFile);

            var parsedTitle = Title.ParseLocalizedString(31, "Title");
            var parsedDescription = Description.ParseLocalizedString(127, "Description");

            for (int i = 0; i < scenario.Names.Length; i++)
               scenario.Names[i].Name = parsedTitle;

            for (int i = 0; i < scenario.Descriptions.Length; i++)
                scenario.Descriptions[i].Name = parsedDescription;

            scenario.ScenarioPath = ScenarioFile;

            var fileName = ScenarioFile.Split('\\').Last();
            scenario.ImageFileBase = $"m_{fileName}";

            scenario.MinimumDesiredPlayers = 2;
            scenario.MaximumDesiredPlayers = 6;
            scenario.GameEngineTeamCounts = GameCategory.DefaultTeamCounts;

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