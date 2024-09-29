using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class MultiplayerMapInfo : TagStructure
    {
        public Guid MapGuid;
        public string ScenarioFile;
        public LocalizedString Title;
        public LocalizedString Description;
        public MapImageInfo Images;
        public List<MapFlags> Flags;
        public List<InsertionPointInfo> InsertionPoints;
        public Dictionary<GameCategory.GameCategoryIndex, byte> MaximumTeamsByGameCategory;
        public DamageReportingType MapDefaultPrimaryWeapon;
        public DamageReportingType MapDefaultPrimaryWeaponForge;

        public enum MapFlags
        {
            DisableSavedFilms = 0,
            HasNoRealGameplay = 1,
            ForgeMap = 2,
            Count = 3,
        }

        public void ConvertMultiplayerMapInfo(BlfScenario scenario) 
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

            GameCategory.ConvertGameCategoryIndexes(MaximumTeamsByGameCategory, scenario.GameEngineTeamCounts);

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

            if (Flags.Contains(MapFlags.ForgeMap))
                scenario.MapFlags |= BlfScenarioFlags.IsForgeOnly;
        }
    }
}