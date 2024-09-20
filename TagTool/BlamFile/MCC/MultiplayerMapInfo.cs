using System;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class MultiplayerMapInfo : TagStructure
    {
        public Guid MapGuid;
        public string ScenarioFile;
        public string Title;
        public string Description;
        public MapImageInfo Images;
        public MapFlags Flags;
        public List<InsertionPointInfo> InsertionPoints;
        public GameCategoryIndex MaximumTeamsByGameCategory;
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

    // TODO: Add Function For Handling MaxTeamOverride value
    public class GameCategoryIndex
    {
        public byte GameCategory_CTF;
        public byte GameCategory_Slayer;
        public byte GameCategory_Oddball;
        public byte GameCategory_KOTH;
        public byte GameCategory_Juggernaut;
        public byte GameCategory_Infection;
        public byte GameCategory_Sandbox;
        public byte GameCategory_VIP;
        public byte GameCategory_Territories;
        public byte GameCategory_Assault;
        public byte GameCategory_GunGame;
    }
}