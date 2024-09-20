using System;
using System.Collections.Generic;
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
        public Dictionary<GameCategoryIndex, byte> MaximumTeamsByGameCategory;
        public DamageReportingType MapDefaultPrimaryWeapon;
        public DamageReportingType MapDefaultPrimaryWeaponForge;
    }

    public enum MapFlags
    {
        DisableSavedFilms = 0,
        HasNoRealGameplay = 1,
        ForgeMap = 2,
        Count = 3,
    }
}