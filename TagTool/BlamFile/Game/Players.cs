using System.Runtime.InteropServices;
using TagTool.Tags;

namespace TagTool.BlamFile.Game
{
    [TagStructure(Size = 0xC8)]
    public class PlayerConfigurationFromClient : TagStructure
    {
        [TagField(Length = 0x10, CharSet = CharSet.Unicode)]
        public string PlayerName;

        public PlayerAppearance Appearance;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public ulong PlayerXuid;
        public bool IsSilverOrGoldLive;
        public bool IsOnlineEnabled;
        public bool IsControllerAttached;
        public byte UserSelectedTeamIndex;
        public bool DesiresVeto;
        public bool DesiresRematch;
        public byte HopperAccessFlags;
        public bool IsFreeLiveGoldAccount;
        public bool IsUserCreatedContentAllowed;
        public bool IsFriendCreatedContentAllowed;
        public byte IsGriefer;
        public byte CampaignDifficultyCompleted;
        public uint BungieNetUserFlags;
        public int GamerRegion;
        public int GamerZone;
        public uint CheatFlags;
        public uint BanFlags;
        public int RepeatedPlayCoefficient;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public bool ExperienceGrowthBanned;
        public QueriedPlayerStatistics QueriedPlayerStatistics;
    }

    [TagStructure(Size = 0x48)]
    public class PlayerConfigurationFromHost : TagStructure
    {
        [TagField(Length = 0x10, CharSet = CharSet.Unicode)]
        public string PlayerName;

        public int PlayerTeam;
        public int PlayerAssignedTeam;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public bool StatsGlobalValid;
        public int StatsGlobalExperience;
        public int StatsGlobalRank;
        public int StatsGlobalGrade;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public bool StatsHopperValid;
        public int StatsHopperSkill;
        public int StatsHopperSkillDisplay;
        public int StatsHopperSkillUpdateWeight;
    }

    [TagStructure(Size = 0x1E)]
    public class PlayerAppearance : TagStructure
    {
        public byte AppearanceFlags;
        public byte PrimaryColor;
        public byte SecondaryColor;
        public byte TertiaryColor;
        public byte PlayerModelChoice;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public byte ForegroundEmblem;
        public byte BackgroundEmblem;
        public byte EmblemFlags;
        public byte EmblemPrimaryColor;
        public byte EmblemSecondaryColor;
        public byte EmblemBackgroundColor;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        [TagField(Length = 0x4)]
        public byte[] SpartanModelArea;

        [TagField(Length = 0x4)]
        public byte[] EliteModelArea;

        [TagField(Length = 0x4, CharSet = CharSet.Unicode)]
        public string ServiceTag;
    }

    [TagStructure(Size = 0x58)]
    public class QueriedPlayerStatistics : TagStructure
    {
        public QueriedPlayerGlobalStatistics GlobalStatistics;
        public QueriedPlayerDisplayedStatistics DisplayedStatistics;
        public QueriedPlayerHopperStatistics HopperStatistics;

        [TagStructure(Size = 0x10)]
        public class QueriedPlayerGlobalStatistics : TagStructure
        {
            public bool Valid;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public int ExperienceBase;
            public int ExperiencePenalty;
            public int HighestSkill;
        }

        [TagStructure(Size = 0x2C)]
        public class QueriedPlayerDisplayedStatistics : TagStructure
        {
            public bool StatsValid;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public int MatchmadeRankedGamesPlayed;
            public int MatchmadeRankedGamesCompleted;
            public int MatchmadeRankedGamesWon;
            public int MatchmadeUnrankedGamesPlayed;
            public int MatchmadeUnrankedGamesCompleted;
            public int HopperExperienceBase;
            public int CustomGamesCompleted;
            public int HopperExperiencePenalty;
            public int FirstPlayed;
            public int LastPlayed;
        }

        [TagStructure(Size = 0x1C)]
        public class QueriedPlayerHopperStatistics : TagStructure
        {
            public bool StatsValid;

            [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public ushort Indentifier;
            public float Mu;
            public float Sigma;
            public int HopperSkill;
            public int GamesPlayed;
            public int GamesCompleted;
            public int GamesWon;
        }
    }
}
