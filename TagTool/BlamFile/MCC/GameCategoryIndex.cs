using System.Collections.Generic;

namespace TagTool.BlamFile.MCC
{
    public class GameCategory
    {
        public enum GameCategoryIndex
        {
            GameCategory_NONE = -1,
            GameCategory_CTF = 0,
            GameCategory_Slayer = 1,
            GameCategory_Oddball = 2,
            GameCategory_KOTH = 3,
            GameCategory_Juggernaut = 4,
            GameCategory_Infection = 5,
            GameCategory_Flood = 6,
            GameCategory_Race = 7,
            GameCategory_Extraction = 8,
            GameCategory_Dominion = 9,
            GameCategory_Regicide = 10,
            GameCategory_Grifball = 11,
            GameCategory_Ricochet = 12,
            GameCategory_Sandbox = 13,
            GameCategory_VIP = 14,
            GameCategory_Territories = 15,
            GameCategory_Assault = 16,
            GameCategory_Payback = 17,
            GameCategory_Campaign = 18,
            GameCategory_Playlist = 19,
            GameCategory_Firefight = 20,
            GameCategory_Stockpile = 21,
            GameCategory_Headhunter = 22,
            GameCategory_Invasion = 23,
            GameCategory_ActionSack = 24,
            GameCategory_SpartanOps = 25,
            GameCategory_PreGameWarmUp = 26,
            GameCategory_GunGame = 27,
            GameCategory_Count = 28,
        }

        public static GameEngineTeams DefaultTeamCounts = new GameEngineTeams 
        {
            NoGametypeTeamCount = 0,
            CtfTeamCount = 2,
            SlayerTeamCount = 8,
            OddballTeamCount = 8,
            KingTeamCount = 8,
            SandboxTeamCount = 8,
            VipTeamCount = 8,
            JuggernautTeamCount = 8,
            TerritoriesTeamCount = 4,
            AssaultTeamCount = 2,
            InfectionTeamCount = 8,
        };

        public static void ConvertGameCategoryIndexes(Dictionary<GameCategoryIndex, byte> gameCategories, GameEngineTeams gameEngineTeams)
        {
            gameEngineTeams = new GameEngineTeams
            {
                NoGametypeTeamCount = 0,
                CtfTeamCount = gameCategories[GameCategoryIndex.GameCategory_CTF],
                SlayerTeamCount = gameCategories[GameCategoryIndex.GameCategory_Slayer],
                OddballTeamCount = gameCategories[GameCategoryIndex.GameCategory_Oddball],
                KingTeamCount = gameCategories[GameCategoryIndex.GameCategory_KOTH],
                SandboxTeamCount = gameCategories[GameCategoryIndex.GameCategory_Sandbox],
                VipTeamCount = gameCategories[GameCategoryIndex.GameCategory_VIP],
                JuggernautTeamCount = gameCategories[GameCategoryIndex.GameCategory_Juggernaut],
                TerritoriesTeamCount = gameCategories[GameCategoryIndex.GameCategory_Territories],
                AssaultTeamCount = gameCategories[GameCategoryIndex.GameCategory_Assault],
                InfectionTeamCount = gameCategories[GameCategoryIndex.GameCategory_Infection],
            };
        }
    }
}
